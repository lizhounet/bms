require(["jquery", 'layui'], function ($) {
    layui.use(['form', 'layer', 'upload', 'laydate'], function () {
        form = layui.form;
        $ = layui.jquery;
        var layer = parent.layer === undefined ? layui.layer : top.layer,
            upload = layui.upload,
            laydate = layui.laydate;
        var fileAccessToken = "";
        $.ajaxSettings.async = false;
        $.post("/User/GetToken", function (res) {
            if (res.stateCode != 200) {
                layer.msg(res.messages);
            }
            else {
                fileAccessToken = res.jsonData;

            }
        });
        $.ajaxSettings.async = true;
        //上传头像
        upload.render({
            elem: '.userFaceBtn',
            url: $('#FileServiceAdress').val(),
            method: "post",
            accept: "images",
            acceptMime: 'image/*',
            auto: false,
            bindAction: "#userFaceUpload",
            choose: function (obj) {
                obj.preview(function (index, file, result) {
                    $('#userFace').attr('src', result); //图片链接（base64）
                    $("#userFaceBtn").hide();
                    $("#userFaceUpload").show();
                });
            },
            before: function (obj) { //obj参数包含的信息，跟 choose回调完全一致，可参见上文。
                layer.msg("头像上传中,请稍等....", { icon: 16, time: 20000 });
            },
            headers: {
                "Authorization": fileAccessToken
            },
            data: {
                StorageMethod: "qiniuyun",
                FileSpaceType: "public"
            },
            done: function (res) {
                console.log(res);
                if (res.StateCode == 200) {
                    //layer.close();
                    layer.msg("头像上传成功");
                    $('#userFace').attr('src', res.JsonData.FileAddress);
                }

            }
        });

        //自定义验证规则
        form.verify({
            username: function (value, item) { //value：表单的值、item：表单的DOM对象
                if (/[\u4e00-\u9fa5]+/.test(value)) {
                    return '用户名不能为汉字';
                }
                if (/\s+/.test(value)) {
                    return '用户名不能包含空格';
                }
                if (!new RegExp("^[a-zA-Z0-9_\u4e00-\u9fa5\\s·]+$").test(value)) {
                    return '用户名不能有特殊字符';
                }
            },
            email: function (value, item) { //value：表单的值、item：表单的DOM对象
                if (value != '') {
                    if (!new RegExp("^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$").test(value)) {
                        return '邮箱格式错误';
                    }
                }
            },
            phone: function (value, item) { //value：表单的值、item：表单的DOM对象
                if (value != '') {
                    if (!new RegExp("^[1][3,4,5,7,8,9][0-9]{9}$").test(value)) {
                        return '手机号格式 wd 错误';
                    }
                }
            },
            qq: function (value, item) { //value：表单的值、item：表单的DOM对象
                if (value != '') {
                    if (!new RegExp("^[0-9][0-9]{4,}$").test(value)) {
                        return 'QQ格式错误';
                    }
                }
            }
        });
        //选择出生日期
        laydate.render({
            elem: '.userBirthday',
            trigger: 'click',
            max: 0,
            mark: { "0-01-22": "生日" },
            done: function (value, date) {
                if (date.month === 1 && date.date === 22) { //点击每年1月22日，弹出提示语
                    layer.msg('今天是周黎的生日,快来送上祝福吧！');
                }
            }
        });
        //提交个人资料
        form.on("submit(changeUser)", function (data) {
            var index = layer.msg('提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
            var postdata = {
                UserId: $(".userId").val(),  //用户id
                UserName: $(".userName").val(),  //用户名
                UserNikeName: $(".userNikeName").val(),  //昵称
                UserBirthday: $(".userBirthday").val(),  //出生日期
                UserQq: $(".userQq").val(),  //qq
                UserAvatar: $(".userAvatar").attr('src'),  //头像
                UserEmail: $(".userEmail").val(),  //邮箱
                UserWx: $(".userWx").val(),  //微信
                UserPhone: $(".userPhone").val(),  //手机号
                UserGroupId: $(".userGroupId").val(),  //所属用户组
                UserSex: data.field.sex,  //性别
                Note: $(".note").val()    //备注
            };
            $.post("/system/user/addoredituser", postdata, function (res) {
                console.log(res);
                layer.close(index);
                if (res.StateCode == 200) {
                    layer.msg(res.Messages + ",请重新登录");
                    setTimeout(function () {
                        window.parent.location.href = '/user/login';
                    }, 500);
                }
                else {
                    layer.msg(res.Messages);
                }

            }, 'json');
            return false; //阻止表单跳转。如果需要表单跳转，去掉这段即可。
        });
    });
});
