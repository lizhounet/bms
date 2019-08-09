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
        //文章列表
        var tableIns = table.render({
            elem: '#blogArticleList',
            url: '/blog/blogarticle/getblogarticlelist',
            cellMinWidth: 95,
            page: true,
            height: "full-125",
            limits: [10, 15, 20, 25],
            limit: 20,
            id: "blogArticleListTable",
            done: function (res, curr, count) {
                //如果是异步请求数据方式，res即为你接口返回的信息。
                //如果是直接赋值的方式，res即为：{data: [], count: 99} data为当前页数据、count为数据总长度
                console.log(res);
            },
            cols: [[
                { type: "checkbox", fixed: "left", width: 50 },
                { field: 'ArticleId', title: 'ID', width: 60, align: "center" },
                { field: 'ArticleTitle', title: '文章标题', width: 350 },
                { field: 'CreateUser', title: '创建者', align: 'center' },
                {
                    field: 'newsTop', title: '是否置顶', align: 'center', templet: function (d) {
                        return '<input type="checkbox" name="articleTop" lay-filter="articleTop" lay-skin="switch" lay-text="是|否" ' + d.newsTop + '>';
                    }
                },
                {
                    field: 'CreateTime', title: '创建时间', align: 'center', minWidth: 110
                },
                { title: '操作', width: 170, templet: '#blogArticleListBar', fixed: "right", align: "center" }
            ]]
        });
        //搜索【此功能需要后台配合，所以暂时没有动态效果演示】
        $(".search_btn").on("click", function () {
            table.reload("blogArticleListTable", {
                page: {
                    curr: 1 //重新从第 1 页开始
                },
                where: {
                    searchstr: $(".searchVal").val()  //搜索的关键字
                }
            });
        });
        //添加文章
        function BlogArticleAdd(edit) {
            var index = layui.layer.open({
                title: "添加/编辑文章",
                type: 2,
                content: "/Blog/BlogArticle/BlogArticleAdd",
                success: function (layero, index) {
                    var body = layui.layer.getChildFrame('body', index);
                    if (edit) {
                        body.find(".lableId").val(edit.LableId);  //站点Id
                        body.find(".lableName").val(edit.LableName);  //站点名称
                        body.find(".note").text(edit.Note);    //备注
                        form.render();
                    }
                    setTimeout(function () {
                        layui.layer.tips('点击此处返回文章列表', '.layui-layer-setwin .layui-layer-close', {
                            tips: 3
                        });
                    }, 500);
                }
            });
            layui.layer.full(index);
        }
        $(".addNews_btn").click(function () {
            BlogArticleAdd();
        });
        //批量删除
        $(".delAll_btn").click(function () {
            var checkStatus = table.checkStatus('blogArticleListTable'),
                data = checkStatus.data,
                LableId = [];
            if (data.length > 0) {
                for (var i in data) {
                    LableId.push(data[i].LableId);
                }
                layer.confirm('确定删除选中的标签？', { icon: 3, title: '提示信息' }, function (index) {
                    $.post("/Blog/BlogArticle/DeleteBlogArticle", {
                        blogLableId: LableId //将需要删除的LableId作为参数传入
                    }, function (res) {
                        layer.msg(res.RetMsg);
                        layer.close(index);
                        if (res.RetCode == 200) {
                            tableIns.reload();
                        }
                    }, "json");
                });
            } else {
                layer.msg("请选择需要删除的标签");
            }
        });
        //列表操作
        table.on('tool(blogLableList)', function (obj) {
            var layEvent = obj.event,
                data = obj.data;
            if (layEvent === 'edit') { //编辑
                BlogLableAdd(data);
            } else if (layEvent === 'del') { //删除
                layer.confirm('确定删除此标签？', { icon: 3, title: '提示信息' }, function (index) {
                    $.post("/Blog/blogArticle/DeleteBlogLable", {
                        blogLableId: data.LableId  //将需要删除的LableId作为参数传入
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