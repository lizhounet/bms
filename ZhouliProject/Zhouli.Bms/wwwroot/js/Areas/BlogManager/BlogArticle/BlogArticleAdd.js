require.config({
    paths: {
    }
});
require(["jquery", 'layui'], function ($) {
    layui.use(['form', 'layer', 'layedit', 'laydate', 'upload'], function () {
        var form = layui.form,
            layer = parent.layer === undefined ? layui.layer : top.layer,
            laypage = layui.laypage,
            upload = layui.upload,
            layedit = layui.layedit,
            laydate = layui.laydate,
            $ = layui.jquery;
        var editIndex = layedit.build("news_content", {
            uploadImage: {
                url: "/upload",
                method: "post",
            }
        });

        //获取上传文件token
        var fileAccessToken = "";
        $.ajaxSettings.async = false;
        $.post("/Token/GetFileServiceToken", function (res) {
            if (res.stateCode != 200) {
                layer.msg(res.messages);
            }
            else {
                fileAccessToken = res.jsonData;

            }
        });
        $.ajaxSettings.async = true;
        //上传缩略图
        upload.render({
            elem: '.thumbBox',
            url: $('#FileServiceAdress').val(),
            method: "post",
            headers: {
                "Authorization": fileAccessToken
            },
            data: {
                StorageMethod: "bendi",
                FileSpaceType: ""
            },
            done: function (res, index, upload) {
                if (res.StateCode == 200) {
                    $('.thumbImg').attr('src', res.JsonData.FileAddress);
                }
                else
                    layer.msg(res.Messages);
                $('.thumbBox').css("background", "#fff");
            }
        });
        form.verify({
            articleTitle: function (val) {
                if (val == '') {
                    return "文章标题不能为空";
                }
            },
            content: function (val) {
                return layedit.sync(editIndex);
            }
        });
        form.on("submit(addNews)", function (data) {
            //截取文章内容中的一部分文字放入文章摘要
            var abstract = layedit.getText(editIndex).substring(0, 50);
            var arr = new Array();
            $("input:checkbox[name='LableId']:checked").each(function (i) {
                arr[i] = $(this).val();
            });
            data.field.lableId = arr;
            console.log(data.field);
            //弹出loading
            var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
            $.post("/blog/blogarticle/addorupdateblogaticle", {
                articleTitle: data.field.articleTitle,  //文章标题
                articleBodySummary: data.field.articleBodySummary,  //文章摘要
                articleBody: data.field.content,  //文章内容
                articleThrink: data.field.articleThrink,  //缩略图
                LableId: data.field.lableId,//所选标签
                articleTop: data.field.articleTop == "on" ? "0" : "1",    //是否置顶
            }, function (res) {
                top.layer.close(index);
                layer.closeAll("iframe");
                layer.msg(res.Messages);
                if (res.StateCode == 200) {
                    //刷新父页面
                    parent.location.reload();
                }

            })
            //setTimeout(function () {
            //    top.layer.close(index);
            //    top.layer.msg("文章添加成功！");
            //    layer.closeAll("iframe");
            //    //刷新父页面
            //    parent.location.reload();
            //}, 500);
            return false;
        });

        //预览
        form.on("submit(look)", function () {
            layer.alert("此功能需要前台展示，实际开发中传入对应的必要参数进行文章内容页面访问");
            return false;
        });
    });
});