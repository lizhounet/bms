import{b as R,r as $,a as b,i as D,o as N,c as i,j as d,d as v,f as t,w as n,l as a,q as h,A as k,z as _,F as U,C as V,n as p,e as z,t as j,k as A}from"./index-4cfb789b.js";import K from"./List-35336454.js";import{I as P,s as L}from"./Info-a68e33af.js";const E=p("\u67E5\u8BE2"),M=p("\u91CD\u7F6E"),q=p(" \u65B0\u5EFA "),W=p(" \u6279\u91CF\u5220\u9664 "),G=p("\u91CD\u7F6E"),H=p(" \u68C0\u7D22 "),J=["onClick"],Q=z("a",{class:"text-danger"},"\u5220\u9664",-1),X={name:"wxKeyordReplyIndex"},oe=Object.assign(X,{setup(Y){const T=R(),o=$({search:{state:!1,vm:{name:null}},loading:!1,pageSizeOptions:[10,20,50,100,500,1e3],rows:10,page:1,total:0,columns:[],data:[]}),C=b(null),g=b(null),u=T.getPowerByMenuId(D.currentRoute.value.meta.menuId),l={onChange(r){const{currentPage:e,pageSize:c}=r;o.page=e==0?1:e,o.rows=c,l.findList()},onResetSearch(){o.page=1;let r=o.search.vm;for(let e in r)r[e]=null;l.findList()},findList(){o.loading=!0,L.findList(o.rows,o.page,o.search.vm).then(r=>{let e=r.data;o.loading=!1,o.page=e.page,o.rows=e.size,o.total=e.total,o.columns=e.columns,o.data=e.dataSource})},deleteList(r){let e=[];r?e.push(r):e=g.value.table.getCheckboxRecords().map(c=>c.id),L.deleteList(e).then(c=>{c.code==1&&(j.message("\u5220\u9664\u6210\u529F!","\u6210\u529F"),l.findList())})},openForm(r){C.value.openForm({visible:!0,key:r})}};return N(()=>{l.findList()}),(r,e)=>{const c=i("a-input"),w=i("a-col"),f=i("a-button"),O=i("a-row"),x=i("a-popconfirm"),S=i("a-checkbox"),F=i("a-popover"),m=i("vxe-column"),B=i("a-divider");return d(),v("div",null,[t(K,{ref_key:"refList",ref:g,tableData:a(o),onOnChange:l.onChange},{search:n(()=>[t(O,{gutter:[15,15]},{default:n(()=>[t(w,{xs:24,sm:12,md:8,lg:6,xl:4},{default:n(()=>[t(c,{value:a(o).search.vm.name,"onUpdate:value":e[0]||(e[0]=s=>a(o).search.vm.name=s),placeholder:"\u540D\u79F0"},null,8,["value"])]),_:1}),t(w,{xs:24,sm:12,md:8,lg:6,xl:4,style:{float:"right"}},{default:n(()=>[t(f,{type:"primary",class:"mr-15",onClick:l.findList},{default:n(()=>[E]),_:1},8,["onClick"]),t(f,{class:"mr-15",onClick:l.onResetSearch},{default:n(()=>[M]),_:1},8,["onClick"])]),_:1})]),_:1})]),"toolbar-left":n(()=>[a(u).insert?(d(),h(f,{key:0,type:"primary",onClick:e[1]||(e[1]=s=>l.openForm())},{icon:n(()=>[t(k,{name:"PlusOutlined"})]),default:n(()=>[q]),_:1})):_("",!0),a(u).delete?(d(),h(x,{key:1,title:"\u60A8\u786E\u5B9A\u8981\u5220\u9664\u5417?",onConfirm:e[2]||(e[2]=s=>l.deleteList()),okText:"\u786E\u5B9A",cancelText:"\u53D6\u6D88"},{default:n(()=>[t(f,{type:"danger"},{icon:n(()=>[t(k,{name:"DeleteOutlined"})]),default:n(()=>[W]),_:1})]),_:1})):_("",!0)]),"toolbar-right":n(()=>[t(c,{value:a(o).search.vm.name,"onUpdate:value":e[3]||(e[3]=s=>a(o).search.vm.name=s),placeholder:"\u540D\u79F0",onKeyup:l.findList},null,8,["value","onKeyup"]),t(f,{onClick:l.onResetSearch},{default:n(()=>[G]),_:1},8,["onClick"]),a(u).search?(d(),h(f,{key:0,onClick:e[4]||(e[4]=s=>a(o).search.state=!a(o).search.state)},{icon:n(()=>[t(k,{name:a(o).search.state?"UpOutlined":"DownOutlined"},null,8,["name"])]),default:n(()=>[H]),_:1})):_("",!0),t(F,null,{content:n(()=>[(d(!0),v(U,null,V(a(o).columns.filter(s=>s.fieldName.substr(0,1)!="_"),(s,y)=>(d(),v("div",{key:y},[t(S,{checked:s.show,"onUpdate:checked":I=>s.show=I,onChange:e[5]||(e[5]=()=>r.nextTick(()=>g.value.table.refreshColumn()))},{default:n(()=>[p(A(s.title),1)]),_:2},1032,["checked","onUpdate:checked"])]))),128))]),default:n(()=>[t(f,null,{default:n(()=>[t(k,{name:"BarsOutlined"})]),_:1})]),_:1})]),"table-col-default":n(()=>[t(m,{field:"keyWord",title:"\u5173\u952E\u8BCD","show-overflow":""}),t(m,{field:"matchTypeText",title:"\u5339\u914D\u7C7B\u578B(\u6A21\u7CCA\u5339\u914D,\u7CBE\u786E\u5339\u914D)","show-overflow":""}),t(m,{field:"takeEffectType",title:"\u751F\u6548\u7C7B\u578B","show-overflow":""}),t(m,{field:"sendTypeText",title:"\u53D1\u9001\u7C7B\u578B","show-overflow":""}),t(m,{field:"sendContent",title:"\u53D1\u9001\u5185\u5BB9","show-overflow":""}),a(u).update||a(u).delete?(d(),h(m,{key:0,field:"id",title:"\u64CD\u4F5C"},{default:n(({row:s})=>[a(u).update?(d(),v("a",{key:0,href:"javascript:void(0)",onClick:y=>l.openForm(s.id)},"\u7F16\u8F91",8,J)):_("",!0),t(B,{type:"vertical"}),a(u).delete?(d(),h(x,{key:1,title:"\u60A8\u786E\u5B9A\u8981\u5220\u9664\u5417?",onConfirm:y=>l.deleteList(s.id),okText:"\u786E\u5B9A",cancelText:"\u53D6\u6D88"},{default:n(()=>[Q]),_:2},1032,["onConfirm"])):_("",!0)]),_:1})):_("",!0)]),_:1},8,["tableData","onOnChange"]),t(P,{ref_key:"refForm",ref:C,onOnSuccess:e[6]||(e[6]=()=>l.findList())},null,512)])}}});export{oe as default};
