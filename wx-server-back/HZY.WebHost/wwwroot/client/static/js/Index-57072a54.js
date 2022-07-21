import{b as B,r as E,a as k,i as I,o as V,c as d,j as r,d as D,f as t,w as e,l as c,q as u,A as y,z as _,e as L,n as i,t as N}from"./index-eda3e6f0.js";import z from"./List-21732a1f.js";import{I as M,s as x}from"./Info-a48921ec.js";import P from"./RoleFunction-c2c1cd23.js";import U from"./RoleDataAuthority-905b51bc.js";import"./organizationService-d533f459.js";const K=i("\u67E5\u8BE2"),q=i("\u91CD\u7F6E"),G=i(" \u65B0\u5EFA "),H=i(" \u6279\u91CF\u5220\u9664 "),J=i("\u5BFC\u51FA Excel"),Q=i(" \u66F4\u591A\u64CD\u4F5C "),X=i("\u91CD\u7F6E"),Y=i(" \u68C0\u7D22 "),Z=i("\u81EA\u5B9A\u4E49\u6743\u9650"),ee=i("\u67E5\u770B\u6240\u6709\u6570\u636E"),te=i("\u4EC5\u67E5\u770B\u672C\u7EC4\u7EC7"),oe=i("\u4EC5\u67E5\u770B\u672C\u7EC4\u7EC7\u548C\u4E0B\u5C5E\u7EC4\u7EC7"),ne=i("\u4EC5\u67E5\u770B\u672C\u4EBA"),ae=i("\u9501\u5B9A"),se=i("\u4E0D\u9501\u5B9A"),le=["onClick"],ie=L("a",{class:"text-danger"},"\u5220\u9664",-1),re=["onClick"],ce=["onClick"],de={name:"system_role"},ke=Object.assign(de,{setup(ue){const O=B(),n=E({search:{state:!1,fieldCount:2,vm:{name:null}},loading:!1,rows:10,page:1,total:0,data:[]}),w=k(null),b=k(null),R=k(null),T=k(null),v=O.getPowerByMenuId(I.currentRoute.value.meta.menuId),s={onChange(l){const{currentPage:o,pageSize:m}=l;n.page=o==0?1:o,n.rows=m,s.findList()},onResetSearch(){n.page=1;let l=n.search.vm;for(let o in l)l[o]=null;s.findList()},findList(){n.loading=!0,x.findList(n.rows,n.page,n.search.vm).then(l=>{let o=l.data;n.loading=!1,n.page=o.page,n.rows=o.size,n.total=o.total,n.data=o.dataSource})},deleteList(l){let o=[];l?o.push(l):o=b.value.table.getCheckboxRecords().map(m=>m.id),x.deleteList(o).then(m=>{m.code==1&&(N.message("\u5220\u9664\u6210\u529F!","\u6210\u529F"),s.findList())})},openForm(l){w.value.openForm({visible:!0,key:l})},exportExcel(){x.exportExcel(n.search.vm)},openRoleFunctionWindow(l){R.value.openWindow({visible:!0,key:l})},openRoleDataAuthorityWindow(l){T.value.openWindow({visible:!0,key:l})}};return V(()=>{s.findList()}),(l,o)=>{const m=d("a-input"),F=d("a-col"),p=d("a-button"),S=d("a-row"),$=d("a-popconfirm"),A=d("a-menu-item"),W=d("a-menu"),j=d("a-dropdown"),f=d("vxe-column"),h=d("a-tag"),g=d("a-divider");return r(),D("div",null,[t(z,{ref_key:"refList",ref:b,tableData:c(n),onOnChange:s.onChange},{search:e(()=>[t(S,{gutter:[15,15]},{default:e(()=>[t(F,{xs:24,sm:12,md:8,lg:6,xl:4},{default:e(()=>[t(m,{value:c(n).search.vm.name,"onUpdate:value":o[0]||(o[0]=a=>c(n).search.vm.name=a),placeholder:"\u540D\u79F0"},null,8,["value"])]),_:1}),t(F,{xs:24,sm:12,md:8,lg:6,xl:4,style:{float:"right"}},{default:e(()=>[t(p,{type:"primary",class:"mr-15",onClick:s.findList},{default:e(()=>[K]),_:1},8,["onClick"]),t(p,{class:"mr-15",onClick:s.onResetSearch},{default:e(()=>[q]),_:1},8,["onClick"])]),_:1})]),_:1})]),"toolbar-left":e(()=>[c(v).insert?(r(),u(p,{key:0,type:"primary",onClick:o[1]||(o[1]=a=>s.openForm())},{icon:e(()=>[t(y,{name:"PlusOutlined"})]),default:e(()=>[G]),_:1})):_("",!0),c(v).delete?(r(),u($,{key:1,title:"\u60A8\u786E\u5B9A\u8981\u5220\u9664\u5417?",onConfirm:o[2]||(o[2]=a=>s.deleteList()),okText:"\u786E\u5B9A",cancelText:"\u53D6\u6D88"},{default:e(()=>[t(p,{type:"danger"},{icon:e(()=>[t(y,{name:"DeleteOutlined"})]),default:e(()=>[H]),_:1})]),_:1})):_("",!0),t(j,null,{overlay:e(()=>[t(W,null,{default:e(()=>[t(A,{key:"1",onClick:s.exportExcel},{default:e(()=>[J]),_:1},8,["onClick"])]),_:1})]),default:e(()=>[t(p,null,{default:e(()=>[Q,t(y,{name:"DownOutlined"})]),_:1})]),_:1})]),"toolbar-right":e(()=>[t(m,{value:c(n).search.vm.name,"onUpdate:value":o[3]||(o[3]=a=>c(n).search.vm.name=a),placeholder:"\u540D\u79F0",onKeyup:s.findList},null,8,["value","onKeyup"]),t(p,{onClick:s.onResetSearch},{default:e(()=>[X]),_:1},8,["onClick"]),c(v).search?(r(),u(p,{key:0,onClick:o[4]||(o[4]=a=>c(n).search.state=!c(n).search.state)},{icon:e(()=>[t(y,{name:c(n).search.state?"UpOutlined":"DownOutlined"},null,8,["name"])]),default:e(()=>[Y]),_:1})):_("",!0)]),"table-col-default":e(()=>[t(f,{field:"number",title:"\u7F16\u53F7",width:"100"}),t(f,{field:"name",title:"\u89D2\u8272\u540D\u79F0"}),t(f,{field:"permissionType",title:"\u6570\u636E\u6743\u9650"},{default:e(({row:a})=>[a.permissionType==1?(r(),u(h,{key:0,color:"success"},{default:e(()=>[Z]),_:1})):_("",!0),a.permissionType==2?(r(),u(h,{key:1,color:"success"},{default:e(()=>[ee]),_:1})):_("",!0),a.permissionType==3?(r(),u(h,{key:2,color:"success"},{default:e(()=>[te]),_:1})):_("",!0),a.permissionType==4?(r(),u(h,{key:3,color:"success"},{default:e(()=>[oe]),_:1})):_("",!0),a.permissionType==5?(r(),u(h,{key:4,color:"success"},{default:e(()=>[ne]),_:1})):_("",!0)]),_:1}),t(f,{field:"deleteLock",title:"\u5220\u9664\u9501\u5B9A"},{default:e(({row:a})=>[a.deleteLock?(r(),u(h,{key:0,color:"success"},{default:e(()=>[ae]),_:1})):(r(),u(h,{key:1,color:"warning"},{default:e(()=>[se]),_:1}))]),_:1}),t(f,{field:"remark",title:"\u5907\u6CE8"}),t(f,{field:"lastModificationTime",title:"\u66F4\u65B0\u65F6\u95F4"}),t(f,{field:"creationTime",title:"\u521B\u5EFA\u65F6\u95F4"}),t(f,{field:"id",title:"\u64CD\u4F5C",width:"300"},{default:e(({row:a})=>[c(v).update?(r(),D("a",{key:0,href:"javascript:void(0)",onClick:C=>s.openForm(a.id)},"\u7F16\u8F91",8,le)):_("",!0),t(g,{type:"vertical"}),c(v).delete?(r(),u($,{key:1,title:"\u60A8\u786E\u5B9A\u8981\u5220\u9664\u5417?",onConfirm:C=>s.deleteList(a.id),okText:"\u786E\u5B9A",cancelText:"\u53D6\u6D88"},{default:e(()=>[ie]),_:2},1032,["onConfirm"])):_("",!0),t(g,{type:"vertical"}),L("a",{href:"javascript:void(0)",onClick:C=>s.openRoleFunctionWindow(a.id)},"\u529F\u80FD\u6743\u9650",8,re),t(g,{type:"vertical"}),L("a",{href:"javascript:void(0)",onClick:C=>s.openRoleDataAuthorityWindow(a.id)},"\u6570\u636E\u6743\u9650",8,ce)]),_:1})]),_:1},8,["tableData","onOnChange"]),t(M,{ref_key:"refForm",ref:w,onOnSuccess:o[5]||(o[5]=()=>s.findList())},null,512),t(P,{ref_key:"refRoleFunction",ref:R},null,512),t(U,{ref_key:"refRoleDataAuthority",ref:T},null,512)])}}});export{ke as default};
