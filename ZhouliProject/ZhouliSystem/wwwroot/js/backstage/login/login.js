require(["jquery", 'layui'], function ($) {
    layui.use(['form', 'layer'], function () {
        var form = layui.form;
        var layer = layui.layer;
        //监听提交
        form.on('submit(login)', function (data) {
            var index = layer.load(3); //风格1的加载
            $.post("/User/UserLogin", data.field, function (res) {
                layer.close(index);
                console.log(res);
            }, 'json');
            return false;
        });
    });
})
