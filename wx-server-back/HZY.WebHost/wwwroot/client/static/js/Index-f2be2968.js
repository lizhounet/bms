import{b as B,r as $,a as L,i as j,o as N,c,j as r,d as v,f as t,w as n,h as a,x as h,B as g,C as p,F as R,E as D,m as _,e as U,t as V,k as z}from"./index-75374896.js";import P from"./List-b64e1c00.js";import{I as A,s as O}from"./Info-c4a37914.js";import"./wxContactService-df14febc.js";const E=_("\u67E5\u8BE2"),K=_("\u91CD\u7F6E"),M=_(" \u65B0\u5EFA "),W=_(" \u6279\u91CF\u5220\u9664 "),q=_("\u91CD\u7F6E"),G=_(" \u68C0\u7D22 "),H=["onClick"],J=["onClick"],Q=U("a",{class:"text-danger"},"\u5220\u9664",-1),X={name:"wxtimedtaskIndex"},ne=Object.assign(X,{setup(Y){const T=B(),o=$({search:{state:!1,vm:{name:null}},loading:!1,pageSizeOptions:[10,20,50,100,500,1e3],rows:10,page:1,total:0,columns:[],data:[]}),C=L(null),w=L(null),d=T.getPowerByMenuId(j.currentRoute.value.meta.menuId);console.log(d);const l={onChange(i){const{currentPage:e,pageSize:u}=i;o.page=e==0?1:e,o.rows=u,l.findList()},onResetSearch(){o.page=1;let i=o.search.vm;for(let e in i)i[e]=null;l.findList()},findList(){o.loading=!0,O.findList(o.rows,o.page,o.search.vm).then(i=>{let e=i.data;o.loading=!1,o.page=e.page,o.rows=e.size,o.total=e.total,o.columns=e.columns,o.data=e.dataSource})},deleteList(i){let e=[];i?e.push(i):e=w.value.table.getCheckboxRecords().map(u=>u.id),O.deleteList(e).then(u=>{u.code==1&&(V.message("\u5220\u9664\u6210\u529F!","\u6210\u529F"),l.findList())})},openForm(i){C.value.openForm({visible:!0,key:i})}};return N(()=>{l.findList()}),(i,e)=>{const u=c("a-input"),x=c("a-col"),f=c("a-button"),S=c("a-row"),y=c("a-popconfirm"),F=c("a-checkbox"),I=c("a-popover"),m=c("vxe-column"),b=c("a-divider");return r(),v("div",null,[t(P,{ref_key:"refList",ref:w,tableData:a(o),onOnChange:l.onChange},{search:n(()=>[t(S,{gutter:[15,15]},{default:n(()=>[t(x,{xs:24,sm:12,md:8,lg:6,xl:4},{default:n(()=>[t(u,{value:a(o).search.vm.name,"onUpdate:value":e[0]||(e[0]=s=>a(o).search.vm.name=s),placeholder:"\u540D\u79F0"},null,8,["value"])]),_:1}),t(x,{xs:24,sm:12,md:8,lg:6,xl:4,style:{float:"right"}},{default:n(()=>[t(f,{type:"primary",class:"mr-15",onClick:l.findList},{default:n(()=>[E]),_:1},8,["onClick"]),t(f,{class:"mr-15",onClick:l.onResetSearch},{default:n(()=>[K]),_:1},8,["onClick"])]),_:1})]),_:1})]),"toolbar-left":n(()=>[a(d).insert?(r(),h(f,{key:0,type:"primary",onClick:e[1]||(e[1]=s=>l.openForm())},{icon:n(()=>[t(g,{name:"PlusOutlined"})]),default:n(()=>[M]),_:1})):p("",!0),a(d).delete?(r(),h(y,{key:1,title:"\u60A8\u786E\u5B9A\u8981\u5220\u9664\u5417?",onConfirm:e[2]||(e[2]=s=>l.deleteList()),okText:"\u786E\u5B9A",cancelText:"\u53D6\u6D88"},{default:n(()=>[t(f,{type:"danger"},{icon:n(()=>[t(g,{name:"DeleteOutlined"})]),default:n(()=>[W]),_:1})]),_:1})):p("",!0)]),"toolbar-right":n(()=>[t(u,{value:a(o).search.vm.name,"onUpdate:value":e[3]||(e[3]=s=>a(o).search.vm.name=s),placeholder:"\u540D\u79F0",onKeyup:l.findList},null,8,["value","onKeyup"]),t(f,{onClick:l.onResetSearch},{default:n(()=>[q]),_:1},8,["onClick"]),a(d).search?(r(),h(f,{key:0,onClick:e[4]||(e[4]=s=>a(o).search.state=!a(o).search.state)},{icon:n(()=>[t(g,{name:a(o).search.state?"UpOutlined":"DownOutlined"},null,8,["name"])]),default:n(()=>[G]),_:1})):p("",!0),t(I,null,{content:n(()=>[(r(!0),v(R,null,D(a(o).columns.filter(s=>s.fieldName.substr(0,1)!="_"),s=>(r(),v("div",null,[t(F,{checked:s.show,"onUpdate:checked":k=>s.show=k,onChange:e[5]||(e[5]=()=>i.nextTick(()=>w.value.table.refreshColumn()))},{default:n(()=>[_(z(s.title),1)]),_:2},1032,["checked","onUpdate:checked"])]))),256))]),default:n(()=>[t(f,null,{default:n(()=>[t(g,{name:"BarsOutlined"})]),_:1})]),_:1})]),"table-col-default":n(()=>[t(m,{field:"receivingObjectWxId",title:"\u63A5\u6536\u5BF9\u8C61wxId","show-overflow":""}),t(m,{field:"receivingObjectName",title:"\u63A5\u6536\u5BF9\u8C61","show-overflow":""}),t(m,{field:"sendTypeText",title:"\u53D1\u9001\u7C7B\u578B",width:"80"}),t(m,{field:"messageTypeText",title:"\u6D88\u606F\u7C7B\u578B","show-overflow":""}),t(m,{field:"sendContent",title:"\u53D1\u9001\u5185\u5BB9","show-overflow":"","min-width":"220"}),t(m,{field:"sendTime",title:"\u53D1\u9001\u65F6\u95F4(cron\u8868\u8FBE\u5F0F)","show-overflow":""}),t(m,{field:"closingRemarks",title:"\u7ED3\u5C3E\u5907\u6CE8","show-overflow":""}),a(d).update||a(d).delete?(r(),h(m,{key:0,field:"id",title:"\u64CD\u4F5C"},{default:n(({row:s})=>[a(d).update?(r(),v("a",{key:0,href:"javascript:void(0)",onClick:k=>l.openForm(s.id)},"\u7F16\u8F91",8,H)):p("",!0),t(b,{type:"vertical"}),a(d).update?(r(),v("a",{key:1,href:"javascript:void(0)",onClick:k=>l.send(s.id)},"\u7ACB\u5373\u53D1\u9001",8,J)):p("",!0),t(b,{type:"vertical"}),a(d).delete?(r(),h(y,{key:2,title:"\u60A8\u786E\u5B9A\u8981\u5220\u9664\u5417?",onConfirm:k=>l.deleteList(s.id),okText:"\u786E\u5B9A",cancelText:"\u53D6\u6D88"},{default:n(()=>[Q]),_:2},1032,["onConfirm"])):p("",!0)]),_:1})):p("",!0)]),_:1},8,["tableData","onOnChange"]),t(A,{ref_key:"refForm",ref:C,onOnSuccess:e[6]||(e[6]=()=>l.findList())},null,512)])}}});export{ne as default};
