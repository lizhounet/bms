layui.use(['form'], function () {
    var form = layui.form,
        $ = layui.jquery; //获取form模块
    zhouliMenu.loadMenu();//加载菜单
    //监听提交
    form.on('submit(saveMenu)', function (data) {
        layer.msg(JSON.stringify(data.field));
        return false;
    });
    //添加根节点
    $("#addRootnode").on('click', function () {
        var selectedNodes = zhouliMenu.getSelectedNodes();
        if (selectedNodes.length !== 1)
            return;
        console.log(selectedNodes);
        zhouliMenu.addNodes(selectedNodes[0], { MenuName: "fasfas", MenuId: "fsaf" });
    });
    //添加子节点
    $("#addSubnode").on('click', function () {
    });
});
//ztree配置
var setting = {
    view: {
        addHoverDom: false,
        removeHoverDom: false,
        selectedMulti: false,
        showTitle: true
    },
    check: {
        enable: false
    },
    data: {
        simpleData: {
            enable: true
        },
        key: {
            name: "MenuName",
            idKey: "MenuId",
            pIdKey: "ParentMenuId"
        }
    },
    edit: {
        enable: false
    }
};
var zhouliMenu = {
    //加载菜单
    loadMenu: function () {
        $.get("/System/Menu/getmenulist", { name: "John", time: "2pm" },
            function (data) {
                console.log(data);
                //绑定zTree
                $.fn.zTree.init($("#treeMenu"), setting, data.JsonData);
                //展开所有节点
                $.fn.zTree.getZTreeObj("treeMenu").expandAll(true);
            }, "json");
    },
    //获取光标选中的(selected)
    getSelectedNodes: function () {
        return $.fn.zTree.getZTreeObj("treeMenu").getSelectedNodes();
    },
    //添加节点
    addNodes: function (parentNode, newNode) {
        $.fn.zTree.getZTreeObj("treeMenu").addNodes(parentNode, newNode);
    }
};
//加载菜单
//function loadMenu() { 

//}
