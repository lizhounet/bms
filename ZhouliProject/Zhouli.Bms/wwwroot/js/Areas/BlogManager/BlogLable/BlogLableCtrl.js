debugger;
require.config({
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
            elem: '#blogLableList',
            url: '/blog/BlogLable/GetBlogLableList',
            cellMinWidth: 95,
            page: true,
            height: "full-125",
            limits: [10, 15, 20, 25],
            limit: 20,
            id: "blogLableListTable",
            done: function (res, curr, count) {
                //如果是异步请求数据方式，res即为你接口返回的信息。
                //如果是直接赋值的方式，res即为：{data: [], count: 99} data为当前页数据、count为数据总长度
                //console.log(res);
            },
            cols: [[
                { type: "checkbox", fixed: "left", width: 50 },
                { field: 'LableId', hide: true },
                { field: 'LableName', title: '博客标签名称', minWidth: 100, align: "center" },
                {
                    field: 'CreateTime', title: '创建时间', align: 'center'
                },
                { field: 'Note', title: '备注', align: 'center', minWidth: 150 },
                { title: '操作', minWidth: 175, templet: '#blogLableListBar', fixed: "right", align: "center" }
            ]]
        });
        //搜索【此功能需要后台配合，所以暂时没有动态效果演示】
        $(".search_btn").on("click", function () {
            table.reload("blogLableListTable", {
                page: {
                    curr: 1 //重新从第 1 页开始
                },
                where: {
                    searchstr: $(".searchVal").val()  //搜索的关键字
                }
            });
        });
        //添加用户
        function BlogLableAdd(edit) {
            var index = layui.layer.open({
                title: "添加/编辑博客标签",
                type: 2,
                content: "/Blog/BlogLable/BlogLableAdd",
                success: function (layero, index) {
                    var body = layui.layer.getChildFrame('body', index);
                    if (edit) {
                        body.find(".lableId").val(edit.LableId);  //站点Id
                        body.find(".lableName").val(edit.LableName);  //站点名称
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
            BlogLableAdd();
        });
        //批量删除
        $(".delAll_btn").click(function () {
            var checkStatus = table.checkStatus('blogLableListTable'),
                data = checkStatus.data,
                LableId = [];
            if (data.length > 0) {
                for (var i in data) {
                    LableId.push(data[i].LableId);
                }
                layer.confirm('确定删除选中的用户？', { icon: 3, title: '提示信息' }, function (index) {
                    $.post("/Blog/BlogLable/DeleteBlogLable", {
                        blogLableId: LableId //将需要删除的LableId作为参数传入
                    }, function (res) {
                        layer.msg(res.Messages);
                        layer.close(index);
                        if (res.StateCode == 200) {
                            tableIns.reload();
                        }
                    }, "json");
                });
            } else {
                layer.msg("请选择需要删除的用户组");
            }
        });
        //列表操作
        table.on('tool(blogLableList)', function (obj) {
            debugger;
            var layEvent = obj.event,
                data = obj.data;
            if (layEvent === 'edit') { //编辑
                BlogLableAdd(data);
            } else if (layEvent === 'del') { //删除
                layer.confirm('确定删除此用户组？', { icon: 3, title: '提示信息' }, function (index) {
                    $.post("/Blog/BlogLable/DeleteBlogLable", {
                        blogLableId: data.LableId  //将需要删除的LableId作为参数传入
                    }, function (res) {
                        layer.msg(res.Messages);
                        layer.close(index);
                        if (res.StateCode == 200) {
                            tableIns.reload();
                        }
                    }, "json");
                });
            }
        });

    });
});