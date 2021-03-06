﻿require.config({
    paths: {
    }
});
require(["jquery", 'layui'], function ($) {
    layui.use(['form', 'layer', 'table', 'laytpl'], function () {
        var form = layui.form,
            layer = parent.layer === undefined ? layui.layer : top.layer,
            $ = layui.jquery,
            laytpl = layui.laytpl,
            table = layui.table;
        //用户组列表
        var tableIns = table.render({
            elem: '#friendshipLinkList',
            url: '/blog/FriendshipLink/GetFriendshipLinkList',
            cellMinWidth: 95,
            page: true,
            height: "full-125",
            limits: [10, 15, 20, 25],
            limit: 20,
            id: "friendshipLinkListTable",
            done: function (res, curr, count) {
                //如果是异步请求数据方式，res即为你接口返回的信息。
                //如果是直接赋值的方式，res即为：{data: [], count: 99} data为当前页数据、count为数据总长度
                //console.log(res);
            },
            cols: [[
                { type: "checkbox", fixed: "left", width: 50 },
                { field: 'FriendshipLinkId', hide: true },
                { field: 'FriendshipLinkName', title: '网站名称', minWidth: 100, align: "center" },
                {
                    field: 'FriendshipLinkUrl', title: '网站地址', align: 'center', minWidth: 150, templet: function (d) {
                        return '<a style="color:dodgerblue;" target="_blank" href="' + d.FriendshipLinkUrl + '"\>' + d.FriendshipLinkUrl + '</a>';
                    }
                },
                { field: 'FriendshipLinkEmail', title: '站长Email', align: 'center', minWidth: 150 },
                {
                    field: 'CreateTime', title: '创建时间', align: 'center'
                },
                { field: 'Note', title: '备注', align: 'center', minWidth: 150 },
                { title: '操作', minWidth: 175, templet: '#friendshipLinkListBar', fixed: "right", align: "center" }
            ]]
        });
        //搜索【此功能需要后台配合，所以暂时没有动态效果演示】
        $(".search_btn").on("click", function () {
            table.reload("friendshipLinkListTable", {
                page: {
                    curr: 1 //重新从第 1 页开始
                },
                where: {
                    searchstr: $(".searchVal").val()  //搜索的关键字
                }
            });
        });
        //添加用户
        function addFriendshipLink(edit) {
            var index = layui.layer.open({
                title: "添加/编辑友情链接",
                type: 2,
                content: "/Blog/FriendshipLink/FriendshipLinkAdd",
                success: function (layero, index) {
                    var body = layui.layer.getChildFrame('body', index);
                    if (edit) {
                        body.find(".friendshipLinkId").val(edit.FriendshipLinkId);  //站点Id
                        body.find(".friendshipLinkName").val(edit.FriendshipLinkName);  //站点名称
                        body.find(".friendshipLinkUrl").val(edit.FriendshipLinkUrl);  //站点Url
                        body.find(".friendshipLinkEmail").val(edit.FriendshipLinkEmail);  //站长邮箱
                        body.find(".note").text(edit.Note);    //备注
                        form.render();
                    }
                    setTimeout(function () {
                        layui.layer.tips('点击此处返回用户组列表', '.layui-layer-setwin .layui-layer-close', {
                            tips: 3
                        });
                    }, 500);
                }
            });
            layui.layer.full(index);
        }
        $(".addNews_btn").click(function () {
            addFriendshipLink();
        });
        //批量删除
        $(".delAll_btn").click(function () {
            var checkStatus = table.checkStatus('friendshipLinkListTable'),
                data = checkStatus.data,
                FriendshipLinkId = [];
            if (data.length > 0) {
                for (var i in data) {
                    FriendshipLinkId.push(data[i].FriendshipLinkId);
                }
                console.log(FriendshipLinkId);
                layer.confirm('确定删除选中的用户？', { icon: 3, title: '提示信息' }, function (index) {
                    $.post("/Blog/FriendshipLink/DeleteFriendshipLink", {
                        FriendshipLinkId: FriendshipLinkId  //将需要删除的UserId作为参数传入
                    }, function (res) {
                        layer.msg(res.RetMsg);
                        layer.close(index);
                        if (res.RetCode == 200) {
                            tableIns.reload();
                        }
                    }, "json");
                });
            } else {
                layer.msg("请选择需要删除的用户组");
            }
        });
        //列表操作
        table.on('tool(friendshipLinkList)', function (obj) {
            var layEvent = obj.event,
                data = obj.data;
            if (layEvent === 'edit') { //编辑
                addFriendshipLink(data);
            } else if (layEvent === 'del') { //删除
                layer.confirm('确定删除此用户组？', { icon: 3, title: '提示信息' }, function (index) {
                    $.post("/Blog/FriendshipLink/DeleteFriendshipLink", {
                        FriendshipLinkId: data.FriendshipLinkId  //将需要删除的UserId作为参数传入
                    }, function (res) {
                        layer.msg(res.RetMsg);
                        layer.close(index);
                        if (res.RetCode == 200) {
                            tableIns.reload();
                        }
                    }, "json");
                });
            } else if (layEvent === 'usable') { //审核
                var _this = $(this),
                    usableText = "是否审核此友情链接？",
                    btnText = "已审核";
                if (_this.text() == "已审核") {
                    layer.msg("不允许重复审核!");
                    return;
                }
                layer.confirm(usableText, {
                    icon: 3,
                    title: '系统提示',
                    cancel: function (index) {
                        layer.close(index);
                    }
                }, function (index) {
                    $.post("/Blog/FriendshipLink/SfFriendshipLink", {
                        FriendshipLinkId: data.FriendshipLinkId
                    }, function (res) {
                        layer.close(index);
                        layer.msg(res.RetMsg);
                        if (res.RetCode == 200) {
                            _this.text(btnText);
                        }
                    }, "json");
                }, function (index) {
                    layer.close(index);
                });
            }
        });

    });
});