import{b as F,r as $,a as x,i as B,o as I,c as d,j as u,d as L,f as n,w as o,l as s,q as v,A as h,z as _,n as m,e as N,t as R}from"./index-eda3e6f0.js";import V from"./List-21732a1f.js";import{I as z,s as b}from"./Info-368312a8.js";const D=m("\u67E5\u8BE2"),j=m("\u91CD\u7F6E"),A=m(" \u65B0\u5EFA "),M=m(" \u6279\u91CF\u5220\u9664 "),P=m("\u91CD\u7F6E"),U=m(" \u68C0\u7D22 "),K=["onClick"],q=N("a",{class:"text-danger"},"\u5220\u9664",-1),E={name:"system_function"},W=Object.assign(E,{setup(G){const w=F(),t=$({search:{state:!1,vm:{name:null}},loading:!1,pageSizeOptions:[10,20,50,100,500,1e3],rows:10,page:1,total:0,data:[]}),g=x(null),k=x(null),f=w.getPowerByMenuId(B.currentRoute.value.meta.menuId),a={onChange(l){const{currentPage:e,pageSize:r}=l;t.page=e==0?1:e,t.rows=r,a.findList()},onResetSearch(){t.page=1;let l=t.search.vm;for(let e in l)l[e]=null;a.findList()},findList(){t.loading=!0,b.findList(t.rows,t.page,t.search.vm).then(l=>{let e=l.data;t.loading=!1,t.page=e.page,t.rows=e.size,t.total=e.total,t.data=e.dataSource})},deleteList(l){let e=[];l?e.push(l):e=k.value.table.getCheckboxRecords().map(r=>r.id),b.deleteList(e).then(r=>{r.code==1&&(R.message("\u5220\u9664\u6210\u529F!","\u6210\u529F"),a.findList())})},openForm(l){g.value.openForm({visible:!0,key:l})}};return I(()=>{a.findList()}),(l,e)=>{const r=d("a-input"),y=d("a-col"),c=d("a-button"),O=d("a-row"),C=d("a-popconfirm"),p=d("vxe-column"),S=d("a-divider");return u(),L("div",null,[n(V,{ref_key:"refList",ref:k,tableData:s(t),onOnChange:a.onChange},{search:o(()=>[n(O,{gutter:[15,15]},{default:o(()=>[n(y,{xs:24,sm:12,md:8,lg:6,xl:4},{default:o(()=>[n(r,{value:s(t).search.vm.name,"onUpdate:value":e[0]||(e[0]=i=>s(t).search.vm.name=i),placeholder:"\u540D\u79F0"},null,8,["value"])]),_:1}),n(y,{xs:24,sm:12,md:8,lg:6,xl:4,style:{float:"right"}},{default:o(()=>[n(c,{type:"primary",class:"mr-15",onClick:a.findList},{default:o(()=>[D]),_:1},8,["onClick"]),n(c,{class:"mr-15",onClick:a.onResetSearch},{default:o(()=>[j]),_:1},8,["onClick"])]),_:1})]),_:1})]),"toolbar-left":o(()=>[s(f).insert?(u(),v(c,{key:0,type:"primary",onClick:e[1]||(e[1]=i=>a.openForm())},{icon:o(()=>[n(h,{name:"PlusOutlined"})]),default:o(()=>[A]),_:1})):_("",!0),s(f).delete?(u(),v(C,{key:1,title:"\u60A8\u786E\u5B9A\u8981\u5220\u9664\u5417?",onConfirm:e[2]||(e[2]=i=>a.deleteList()),okText:"\u786E\u5B9A",cancelText:"\u53D6\u6D88"},{default:o(()=>[n(c,{type:"danger"},{icon:o(()=>[n(h,{name:"DeleteOutlined"})]),default:o(()=>[M]),_:1})]),_:1})):_("",!0)]),"toolbar-right":o(()=>[n(r,{value:s(t).search.vm.name,"onUpdate:value":e[3]||(e[3]=i=>s(t).search.vm.name=i),placeholder:"\u540D\u79F0",onKeyup:a.findList},null,8,["value","onKeyup"]),n(c,{onClick:a.onResetSearch},{default:o(()=>[P]),_:1},8,["onClick"]),s(f).search?(u(),v(c,{key:0,onClick:e[4]||(e[4]=i=>s(t).search.state=!s(t).search.state)},{icon:o(()=>[n(h,{name:s(t).search.state?"UpOutlined":"DownOutlined"},null,8,["name"])]),default:o(()=>[U]),_:1})):_("",!0)]),"table-col-default":o(()=>[n(p,{field:"name",title:"\u540D\u79F0"}),n(p,{field:"byName",title:"\u82F1\u6587\u540D\u79F0"}),n(p,{field:"lastModificationTime",title:"\u66F4\u65B0\u65F6\u95F4"}),n(p,{field:"creationTime",title:"\u521B\u5EFA\u65F6\u95F4"}),n(p,{field:"id",title:"\u64CD\u4F5C"},{default:o(({row:i})=>[s(f).update?(u(),L("a",{key:0,href:"javascript:void(0)",onClick:T=>a.openForm(i.id)},"\u7F16\u8F91",8,K)):_("",!0),n(S,{type:"vertical"}),s(f).delete?(u(),v(C,{key:1,title:"\u60A8\u786E\u5B9A\u8981\u5220\u9664\u5417?",onConfirm:T=>a.deleteList(i.id),okText:"\u786E\u5B9A",cancelText:"\u53D6\u6D88"},{default:o(()=>[q]),_:2},1032,["onConfirm"])):_("",!0)]),_:1})]),_:1},8,["tableData","onOnChange"]),n(z,{ref_key:"refForm",ref:g,onOnSuccess:e[5]||(e[5]=()=>a.findList())},null,512)])}}});export{W as default};
