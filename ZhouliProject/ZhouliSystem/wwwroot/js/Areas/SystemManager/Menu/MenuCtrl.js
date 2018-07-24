layui.use(['form', 'layer'], function () {
    var form = layui.form,
        $ = layui.jquery,
        layer = layui.layer; //获取form模块
    zhouliMenu.loadMenu();//加载菜单
    //监听提交
    form.on('submit(saveMenu)', function (data) {
        layer.msg(JSON.stringify(data.field));
        return false;
    });
    //添加根节点
    $("#addRootnode").on('click', function () {
        var ztree = zhouliMenu.getZtreeObj();
        var selectedNodes = ztree.getSelectedNodes();
        if (selectedNodes.length == 0) {
            layer.msg("请先选中一个菜单节点");
            return;
        }
        var node = {
            MenuName: $("").val(),
            MenuSort: "",
            MenuUrl: "",
            ParentMenuId: "",
            MenuIcon: ""
        };
        $.post("test.php", node,
            function (res) {
                console.log(res);
            }, "json");
    });
    //添加子节点
    $("#addSubnode").on('click', function () {
    });
});
//ztree配置
var setting = {
    view: {
        addHoverDom: addHoverDom,
        removeHoverDom: removeHoverDom,
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
        enable: true
    },
    callback: {
        beforeRename: editBeforeName//用于捕获节点编辑名称结束（Input 失去焦点 或 按下 Enter 键）之后，更新节点名称数据之前的事件回调函数，并且根据返回值确定是否允许更改名称的操作
    }
};
//添加菜单
function addHoverDom(treeId, treeNode) {
    var sObj = $("#" + treeNode.tId + "_span");
    if (treeNode.editNameFlag || $("#addBtn_" + treeNode.tId).length > 0) return;
    var addStr = "<span class='button add' id='addBtn_" + treeNode.tId
        + "' title='add node' onfocus='this.blur();'></span>";
    sObj.after(addStr);
    var btn = $("#addBtn_" + treeNode.tId);
    if (btn) btn.bind("click", function () {
        var zTree = $.fn.zTree.getZTreeObj("treeMenu");
        var node = { MenuId: createGuid(), ParentMenuId: treeNode.MenuId, MenuName: "新建菜单1" }
        zTree.addNodes(treeNode, node);
        //添加之后启用编辑状态
        zTree.editName(zTree.getNodeByParam("MenuId", node.MenuId, null));
        return false;
    });
};
//移除菜单
function removeHoverDom(treeId, treeNode) {
    $("#addBtn_" + treeNode.tId).unbind().remove();
};
function editBeforeName(treeId, treeNode, newName, isCancel) {
    console.log(treeNode);
    $("#MenuId").val(treeNode.MenuId);
    $("#MenuName").val(newName);
    $("#ParentMenuId").val(treeNode.ParentMenuId);
    $("#MenuUrl").val(treeNode.MenuUrl);
    $("#MenuSort").val(treeNode.MenuSort);
    $("#Note").val(treeNode.Note);
}
//js生成guid
function createGuid() {
    var s = [];
    var hexDigits = "0123456789abcdef";
    for (var i = 0; i < 36; i++) {
        s[i] = hexDigits.substr(Math.floor(Math.random() * 0x10), 1);
    }
    s[14] = "4";  // bits 12-15 of the time_hi_and_version field to 0010
    s[19] = hexDigits.substr((s[19] & 0x3) | 0x8, 1);  // bits 6-7 of the clock_seq_hi_and_reserved to 01
    s[8] = s[13] = s[18] = s[23] = "-";

    var uuid = s.join("");
    return uuid;
}
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
    getZtreeObj: function () {
        return $.fn.zTree.getZTreeObj("treeMenu");
    }
};

