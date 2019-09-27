require.config({
    paths: {
    }
});
require(["jquery", 'layui'], function ($) {
    layui.use(['form', 'layer', 'upload'], function () {
        var form = layui.form;
        layer = parent.layer === undefined ? layui.layer : top.layer,
            $ = layui.jquery,
            upload = layui.upload;
        //获取上传文件token
        var fileAccessToken = "";
        $.ajaxSettings.async = false;
        $.post("/Token/GetFileServiceToken", function (res) {
            if (res.RetCode != 200) {
                layer.msg(res.RetMsg);
            }
            else {
                fileAccessToken = res.Data;

            }
        });
        $.ajaxSettings.async = true;
        //上传轮播图
        upload.render({
            elem: '.thumbBox'
            , url: $('#FileServiceAdress').val()
            , headers: {
                "Authorization": fileAccessToken
            }
            , data: {
                StorageMethod: "qiniuyun",
                FileSpaceType: "public"
            }
            , before: function (obj) { //obj参数包含的信息，跟 choose回调完全一致，可参见上文。
                top.layer.msg('上传中',{ icon: 16, time: false});
            }
            , done: function (res) {
                if (res.RetCode == 200) {
                    $("#navigationimg").attr("src", res.Data.FileAddress);
                    top.layer.closeAll();
                    top.layer.msg("上传成功");
                }
            }
        });
        form.on("submit(addBlogNavigationImg)", function (data) {
            //弹出loading
            var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
            // 实际使用时的提交信息
            $.post("/Blog/BlogNavigationImg/AddorUpdateBlogNavigationImg", {
                LableId: $(".describe").val(),  //站点名称
                LableName: $(".lableName").val(),  //站点名称
                Note: $(".note").val()    //备注
            }, function (res) {
                console.log(res);
                top.layer.close(index);
                top.layer.msg(res.RetMsg);
                if (res.RetCode == 200) {
                    layer.closeAll("iframe");
                    //刷新父页面
                    parent.location.reload();
                }

            }, 'json');
            return false;
        });
        //自定义验证规则
        form.verify({
            lableName: function (value, item) { //value：表单的值、item：表单的DOM对象
                if (value == "") {
                    return "博客标签名称不能为空";
                }
            }
        });
    });
});