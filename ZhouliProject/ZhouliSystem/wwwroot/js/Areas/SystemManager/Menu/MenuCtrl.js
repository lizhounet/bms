layui.use(['form'], function () {
    var form = layui.form; //获取form模块
    var setting = {
        view: {
            addHoverDom: false,
            removeHoverDom: false,
            selectedMulti: false,
            showTitle: true
        },
        check: {
            enable: true
        },
        data: {
            simpleData: {
                enable: true
            },
            key: {
                name: "MenuName",
                idKey: "MenuId",
                pIdKey: "ParentMenuId",
            }
        },
        edit: {
            enable: false
        }
    };
    $.get("/System/Menu/getmenulist", { name: "John", time: "2pm" },
        function (data) {
            console.log(data);
            //绑定zTree
            $.fn.zTree.init($("#treeMenu"), setting, data.JsonData);
            //展开所有节点
            $.fn.zTree.getZTreeObj("treeMenu").expandAll(true);
        }, "json");
});