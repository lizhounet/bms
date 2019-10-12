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
        //轮播图列表
        var tableIns = table.render({
            elem: '#blogNavigationImgList',
            url: '/blog/BlogNavigationImg/GetBlogNavigationImgList',
            cellMinWidth: 95,
            page: true,
            height: "full-125",
            limits: [10, 15, 20, 25],
            limit: 20,
            id: "blogNavigationImgListTable",
            done: function (res, curr, count) {
                //如果是异步请求数据方式，res即为你接口返回的信息。
                //如果是直接赋值的方式，res即为：{data: [], count: 99} data为当前页数据、count为数据总长度
                //console.log(res);
            },
            cols: [[
                { type: "checkbox", fixed: "left", width: 50 },
                { field: 'NavigationImgId', hide: true },
                { field: 'NavigationImgDescribe', title: '描述', minWidth: 100, align: "center" },
                {
                    field: 'NavigationImgUrl', title: '轮播图', align: "center", templet: function (d) {
                        return '<div><img  src="' + d.NavigationImgUrl + '" /></div>';
                    }
                },
                {
                    field: 'CreateTime', title: '创建时间', align: 'center'
                },
                { field: 'Note', title: '备注', align: 'center', minWidth: 150 },
                { title: '操作', minWidth: 175, templet: '#blogNavigationImgListBar', fixed: "right", align: "center" }
            ]]
        });
        //搜索【此功能需要后台配合，所以暂时没有动态效果演示】
        $(".search_btn").on("click", function () {
            table.reload("blogNavigationImgListTable", {
                page: {
                    curr: 1 //重新从第 1 页开始
                },
                where: {
                    searchstr: $(".searchVal").val()  //搜索的关键字
                }
            });
        });
        //添加轮播图
        function BlogNavigationImgAdd(edit) {
            var index = layui.layer.open({
                title: "添加/编辑轮播图",
                type: 2,
                content: "/Blog/BlogNavigationImg/BlogNavigationImgAdd",
                success: function (layero, index) {
                    var body = layui.layer.getChildFrame('body', index);
                    if (edit) {
                        body.find(".NavigationImgId").val(edit.NavigationImgId);  //轮播图id
                        body.find(".NavigationImgDescribe").val(edit.NavigationImgDescribe);  //描述
                        body.find(".NavigationImgUrl").attr("src", edit.NavigationImgUrl);  //轮播图
                        body.find(".Note").text(edit.Note);    //备注
                        form.render();
                    }
                    setTimeout(function () {
                        layui.layer.tips('点击此处返回轮播图列表', '.layui-layer-setwin .layui-layer-close', {
                            tips: 3
                        });
                    }, 500);
                }
            });
            layui.layer.full(index);
        }
        $(".addNews_btn").click(function () {
            BlogNavigationImgAdd();
        });
        //批量删除
        $(".delAll_btn").click(function () {
            var checkStatus = table.checkStatus('blogNavigationImgListTable'),
                data = checkStatus.data,
                arrNavigationImgId = [];
            if (data.length > 0) {
                for (var i in data) {
                    arrNavigationImgId.push(data[i].NavigationImgId);
                }
                layer.confirm('确定删除选中的轮播图？', { icon: 3, title: '提示信息' }, function (index) {
                    $.post("/Blog/BlogNavigationImg/DeleteBlogNavigationImg", {
                        blogNavigationImgId: arrNavigationImgId //将需要删除的NavigationImgId作为参数传入
                    }, function (res) {
                        layer.msg(res.RetMsg);
                        layer.close(index);
                        if (res.RetCode == 200) {
                            tableIns.reload();
                        }
                    }, "json");
                });
            } else {
                layer.msg("请选择需要删除的轮播图");
            }
        });
        //列表操作
        table.on('tool(blogNavigationImgList)', function (obj) {
            var layEvent = obj.event,
                data = obj.data;
            if (layEvent === 'edit') { //编辑
                BlogNavigationImgAdd(data);
            } else if (layEvent === 'del') { //删除
                layer.confirm('确定删除此轮播图？', { icon: 3, title: '提示信息' }, function (index) {
                    $.post("/Blog/BlogNavigationImg/DeleteBlogNavigationImg", {
                        blogNavigationImgId: data.NavigationImgId  //将需要删除的NavigationId作为参数传入
                    }, function (res) {
                        layer.msg(res.RetMsg);
                        layer.close(index);
                        if (res.RetCode == 200) {
                            tableIns.reload();
                        }
                    }, "json");
                });
            }
        });

    });
});