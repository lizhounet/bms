require.config({
    paths: {
    }
});
require(["jquery", 'layui'], function ($) {
    layui.use(['form', 'layer', 'laydate'], function () {
        var form = layui.form;
        var laydate = layui.laydate;
        layer = parent.layer === undefined ? layui.layer : top.layer,
            $ = layui.jquery;
        //执行一个laydate实例
        laydate.render({
            elem: '.userBirthday'//指定元素
        });
        form.on("submit(addBlogLable)", function (data) {
            //弹出loading
            var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
            // 实际使用时的提交信息
            $.post("/Blog/BlogLable/AddorUpdateBlogLable", {
                LableId: $(".lableId").val(),  //站点名称
                LableName: $(".lableName").val(),  //站点名称
                Note: $(".note").val()    //备注
            }, function (res) {
                console.log(res);
                top.layer.close(index);
                top.layer.msg(res.Messages);
                if (res.StateCode == 200) {
                    layer.closeAll("iframe");
                    //刷新父页面
                    parent.location.reload();
                }

            }, 'json');
            return false;
        });
    });
});