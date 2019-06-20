require.config({
    paths: {
    }
});
require(["jquery", 'layui'], function ($) {
    layui.use(['form', 'layer', 'layedit', 'laydate', 'upload'], function () {
        var form = layui.form
        layer = parent.layer === undefined ? layui.layer : top.layer,
            laypage = layui.laypage,
            upload = layui.upload,
            layedit = layui.layedit,
            laydate = layui.laydate,
            $ = layui.jquery;

        //用于同步编辑器内容到textarea
        layedit.sync(editIndex);

        //上传缩略图
        upload.render({
            elem: '.thumbBox',
            url: '/',
            method: "get",  //此处是为了演示之用，实际使用中请将此删除，默认用post方式提交
            done: function (res, index, upload) {
                alert();
                var num = parseInt(4 * Math.random());  //生成0-4的随机数，随机显示一个头像信息
                $('.thumbImg').attr('src', res.data[num].src);
                $('.thumbBox').css("background", "#fff");
            }
        });
        form.verify({
            newsName: function (val) {
                if (val == '') {
                    return "文章标题不能为空";
                }
            },
            content: function (val) {
                if (val == '') {
                    return "文章内容不能为空";
                }
            }
        })
        form.on("submit(addNews)", function (data) {
            //截取文章内容中的一部分文字放入文章摘要
            var abstract = layedit.getText(editIndex).substring(0, 50);
            //弹出loading
            var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
            // 实际使用时的提交信息
            // $.post("上传路径",{
            //     newsName : $(".newsName").val(),  //文章标题
            //     abstract : $(".abstract").val(),  //文章摘要
            //     content : layedit.getContent(editIndex).split('<audio controls="controls" style="display: none;"></audio>')[0],  //文章内容
            //     newsImg : $(".thumbImg").attr("src"),  //缩略图
            //     classify : '1',    //文章分类
            //     newsStatus : $('.newsStatus select').val(),    //发布状态
            //     newsTime : submitTime,    //发布时间
            //     newsTop : data.filed.newsTop == "on" ? "checked" : "",    //是否置顶
            // },function(res){
            //
            // })
            setTimeout(function () {
                top.layer.close(index);
                top.layer.msg("文章添加成功！");
                layer.closeAll("iframe");
                //刷新父页面
                parent.location.reload();
            }, 500);
            return false;
        })

        //预览
        form.on("submit(look)", function () {
            layer.alert("此功能需要前台展示，实际开发中传入对应的必要参数进行文章内容页面访问");
            return false;
        })

        //创建一个编辑器
        var editIndex = layedit.build('news_content', {
            height: 535,
            uploadImage: {
                url: "../../json/newsImg.json"
            }
        });
    });
});