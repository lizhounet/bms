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
                $("[data-field='ArticleSortValue']").css('display', 'none');//隐藏列
            },
            cols: [[
                { type: "checkbox", fixed: "left", width: 50 },
                { field: 'ArticleSortValue', title: '排序号' },
                { field: 'ArticleId', title: 'ID', width: 60, align: "center" },
                { field: 'ArticleTitle', title: '文章标题', width: 400, align: "center" },
                {
                    field: 'ArticleThrink', title: '文章缩略图', align: "center", templet: function (d) {
                        return '<div><img  src="' + d.ArticleThrink+'" /></div>';
                    }
                },
                { field: 'ArticleLikeNum', title: '点赞量', align: "center" },
                { field: 'ArticleCommentNum', title: '评论量', align: "center" },
                { field: 'ArticleBrowsingNum', title: '浏览量', align: "center" },
                { field: 'CreateUser', title: '创建者', align: 'center' },
                {
                    field: 'ArticleTop', title: '是否置顶', align: 'center', templet: function (d) {
                        if (d.ArticleTop)
                            return '<input type="checkbox" name="switchArticleTop"  lay-filter="switchArticleTop" lay-skin="switch"  lay-text="是|否" checked >';
                        else
                            return '<input type="checkbox" name="switchArticleTop"  lay-filter="switchArticleTop" lay-skin="switch"  lay-text="是|否" >';
                    }
                },
                {
                    field: 'CreateTime', title: '创建时间', align: 'center'
                },
                { title: '操作', minWidth: 175, templet: '#blogArticleListBar', fixed: "right", align: "center" }
            ]]
        });
        form.on("switch(switchArticleTop)", function (obj) {
            // 获取当前控件                                                                  
            var selectIfKey = obj.othis;
            // 获取当前所在行                                                                 
            var parentTr = selectIfKey.parents("tr");
            //eq(2): 代表的是表头字段位置    .layui-table-cell: 这个元素是我找表格div找出来的..[失望] 
            var ArticleId = $(parentTr).find("td:eq(2)").find(".layui-table-cell").text();
            $.ajaxSettings.async = false;
            $.post("/Blog/BlogArticle/IsBlogArticleTop", {
                ArticleId: ArticleId,
                ArticleTop: obj.elem.checked
            }, function (res) {
                $.ajaxSettings.async = true;
                layer.msg(res.RetMsg);
                return res.RetCode == 200 ? true : false;
            });
            $.ajaxSettings.async = true;
            return false;
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
                        body.find(".articleId").val(edit.ArticleId);  //文章id
                        body.find(".articleSortValue").val(edit.ArticleSortValue);  //排序号
                        body.find(".articleTitle").val(edit.ArticleTitle);  //文章标题
                        body.find(".articleBodySummary").val(edit.ArticleBodySummary);  //内容摘要
                        body.find(".articleThrink").attr("src", edit.ArticleThrink);    //文章缩略图
                        var lableCheckbox = body.find("input[name='lableId']");
                        for (var j = 0; j < edit.LableInfo.length; j++) { //数据库返回的需要选中项的值                      
                            for (var i = 0; i < lableCheckbox.length; i++) {//遍历checkbox所有项
                                if (lableCheckbox[i].value == edit.LableInfo[j].LableId) {
                                    lableCheckbox[i].checked = true;//设置选中项
                                }
                            }
                        }
                        body.find("#articleTop")[0].checked = edit.ArticleTop;//是否置顶
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
                ArticleId = [];
            if (data.length > 0) {
                for (var i in data) {
                    ArticleId.push(data[i].ArticleId);
                }
                layer.confirm('确定删除选中的文章？', { icon: 3, title: '提示信息' }, function (index) {
                    $.post("/Blog/BlogArticle/DeleteBlogArticle", {
                        ArticleId: ArticleId //将需要删除的LableId作为参数传入
                    }, function (res) {
                        layer.msg(res.RetMsg);
                        layer.close(index);
                        if (res.RetCode == 200) {
                            tableIns.reload();
                        }
                    }, "json");
                });
            } else {
                layer.msg("请选择需要删除的文章");
            }
        });
        //列表操作
        table.on('tool(blogArticleList)', function (obj) {
            var layEvent = obj.event,
                data = obj.data;
            if (layEvent === 'edit') { //编辑
                BlogArticleAdd(data);
            } else if (layEvent === 'del') { //删除
                layer.confirm('确定删除此文章？', { icon: 3, title: '提示信息' }, function (index) {
                    $.post("/Blog/blogArticle/DeleteBlogArticle", {
                        ArticleId: data.ArticleId  //将需要删除的LableId作为参数传入
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