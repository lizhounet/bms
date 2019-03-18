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
        form.on("submit(addFriendshipLink)", function (data) {
            //弹出loading
            var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
            debugger;
            // 实际使用时的提交信息
            $.post("/Blog/FriendshipLink/AddorUpdateFriendshipLink", {
                FriendshipLinkId: $(".friendshipLinkId").val(),  //站点名称
                FriendshipLinkName: $(".friendshipLinkName").val(),  //站点名称
                FriendshipLinkUrl: $(".friendshipLinkUrl").val(),  //站点Url
                FriendshipLinkEmail: $(".friendshipLinkEmail").val(),  //站长邮箱
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
        //自定义验证规则
        form.verify({
            friendshipLinkName: function (value, item) { //value：表单的值、item：表单的DOM对象
                if (value == "") {
                    return "网站名称不能为空";
                }
            },
            friendshipLinkUrl: function (value, item) { //value：表单的值、item：表单的DOM对象
                if (value == "") {
                    return "网站地址不能为空";
                }
            },
            friendshipLinkEmail: function (value, item) { //value：表单的值、item：表单的DOM对象
                if (value == "") {
                    return "站长邮箱不能为空";
                }
                if (value != "") {
                    if (!new RegExp("^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$").test(value)) {
                        return '站长邮箱格式错误';
                    }
                }
            }
        });
    });
});