import{b as N,r as U,a as y,i as D,o as V,c as u,j as r,d as m,f as t,w as a,l,q as g,A as T,v as f,F as j,C as z,n as k,e as A,t as x,k as P}from"./index-a74470de.js";import q from"./List-80e7d187.js";import{I as K,s as h}from"./Info-3cef453f.js";import M from"./Cdrawer-e7ce9caa.js";import"./wxContactService-868c6ea2.js";const E=k("\u67E5\u8BE2"),W=k("\u91CD\u7F6E"),G=k(" \u65B0\u5EFA "),H=k(" \u6279\u91CF\u5220\u9664 "),J=k("\u91CD\u7F6E"),Q=k(" \u68C0\u7D22 "),X=["onClick"],Y=["onClick"],Z=["onClick"],ee=["onClick"],te=["onClick"],ne=A("a",{class:"text-danger"},"\u5220\u9664",-1),ae={name:"wxtimedtaskIndex"},ce=Object.assign(ae,{setup(oe){const F=N(),n=U({search:{state:!1,vm:{name:null}},loading:!1,pageSizeOptions:[10,20,50,100,500,1e3],rows:10,page:1,total:0,columns:[],data:[]}),L=y(null),w=y(null),b=y(!1),O=y(null),d=F.getPowerByMenuId(D.currentRoute.value.meta.menuId);console.log(d);const s={onChange(i){const{currentPage:e,pageSize:p}=i;n.page=e==0?1:e,n.rows=p,s.findList()},onResetSearch(){n.page=1;let i=n.search.vm;for(let e in i)i[e]=null;s.findList()},findList(){n.loading=!0,h.findList(n.rows,n.page,n.search.vm).then(i=>{let e=i.data;n.loading=!1,n.page=e.page,n.rows=e.size,n.total=e.total,n.columns=e.columns,n.data=e.dataSource})},deleteList(i){let e=[];i?e.push(i):e=w.value.table.getCheckboxRecords().map(p=>p.id),h.deleteList(e).then(p=>{p.code==1&&(x.message("\u5220\u9664\u6210\u529F!","\u6210\u529F"),s.findList())})},openForm(i){L.value.openForm({visible:!0,key:i})},execTimedTask(i){h.execTimedTask(i).then(e=>{e.code==1&&(x.message("\u6267\u884C\u6210\u529F!","\u6210\u529F"),s.findList())})},startTimdTask(i){h.startTimdTask(i).then(e=>{e.code==1&&(x.message("\u542F\u52A8\u6210\u529F!","\u6210\u529F"),s.findList())})},stopTimdTask(i){h.stopTimdTask(i).then(e=>{e.code==1&&(x.message("\u505C\u6B62\u6210\u529F!","\u6210\u529F"),s.findList())})},showLog(i){h.queryRunLog(i).then(e=>{e.code==1&&(b.value=!0,O.value.state.data=e.data)})}};return V(()=>{s.findList()}),(i,e)=>{const p=u("a-input"),S=u("a-col"),_=u("a-button"),I=u("a-row"),$=u("a-popconfirm"),R=u("a-checkbox"),B=u("a-popover"),c=u("vxe-column"),C=u("a-divider");return r(),m("div",null,[t(q,{ref_key:"refList",ref:w,tableData:l(n),onOnChange:s.onChange},{search:a(()=>[t(I,{gutter:[15,15]},{default:a(()=>[t(S,{xs:24,sm:12,md:8,lg:6,xl:4},{default:a(()=>[t(p,{value:l(n).search.vm.name,"onUpdate:value":e[0]||(e[0]=o=>l(n).search.vm.name=o),placeholder:"\u540D\u79F0"},null,8,["value"])]),_:1}),t(S,{xs:24,sm:12,md:8,lg:6,xl:4,style:{float:"right"}},{default:a(()=>[t(_,{type:"primary",class:"mr-15",onClick:s.findList},{default:a(()=>[E]),_:1},8,["onClick"]),t(_,{class:"mr-15",onClick:s.onResetSearch},{default:a(()=>[W]),_:1},8,["onClick"])]),_:1})]),_:1})]),"toolbar-left":a(()=>[l(d).insert?(r(),g(_,{key:0,type:"primary",onClick:e[1]||(e[1]=o=>s.openForm())},{icon:a(()=>[t(T,{name:"PlusOutlined"})]),default:a(()=>[G]),_:1})):f("",!0),l(d).delete?(r(),g($,{key:1,title:"\u60A8\u786E\u5B9A\u8981\u5220\u9664\u5417?",onConfirm:e[2]||(e[2]=o=>s.deleteList()),okText:"\u786E\u5B9A",cancelText:"\u53D6\u6D88"},{default:a(()=>[t(_,{type:"danger"},{icon:a(()=>[t(T,{name:"DeleteOutlined"})]),default:a(()=>[H]),_:1})]),_:1})):f("",!0)]),"toolbar-right":a(()=>[t(p,{value:l(n).search.vm.name,"onUpdate:value":e[3]||(e[3]=o=>l(n).search.vm.name=o),placeholder:"\u540D\u79F0",onKeyup:s.findList},null,8,["value","onKeyup"]),t(_,{onClick:s.onResetSearch},{default:a(()=>[J]),_:1},8,["onClick"]),l(d).search?(r(),g(_,{key:0,onClick:e[4]||(e[4]=o=>l(n).search.state=!l(n).search.state)},{icon:a(()=>[t(T,{name:l(n).search.state?"UpOutlined":"DownOutlined"},null,8,["name"])]),default:a(()=>[Q]),_:1})):f("",!0),t(B,null,{content:a(()=>[(r(!0),m(j,null,z(l(n).columns.filter(o=>o.fieldName.substr(0,1)!="_"),o=>(r(),m("div",null,[t(R,{checked:o.show,"onUpdate:checked":v=>o.show=v,onChange:e[5]||(e[5]=()=>i.nextTick(()=>w.value.table.refreshColumn()))},{default:a(()=>[k(P(o.title),1)]),_:2},1032,["checked","onUpdate:checked"])]))),256))]),default:a(()=>[t(_,null,{default:a(()=>[t(T,{name:"BarsOutlined"})]),_:1})]),_:1})]),"table-col-default":a(()=>[t(c,{field:"receivingObjectWxId",title:"\u63A5\u6536\u5BF9\u8C61wxId",width:"150"}),t(c,{field:"receivingObjectName",title:"\u63A5\u6536\u5BF9\u8C61",width:"200"}),t(c,{field:"sendTypeText",title:"\u53D1\u9001\u7C7B\u578B",width:"80"}),t(c,{field:"sendContent",title:"\u53D1\u9001\u5185\u5BB9",width:"250"}),t(c,{field:"sendTime",title:"\u53D1\u9001\u65F6\u95F4(cron\u8868\u8FBE\u5F0F)",width:"150"}),t(c,{field:"closingRemarks",title:"\u7ED3\u5C3E\u5907\u6CE8",width:"100"}),t(c,{field:"taskStateText",title:"\u8FD0\u884C\u72B6\u6001",width:"100"}),t(c,{field:"creationTime",title:"\u521B\u5EFA\u65F6\u95F4",width:"150"}),l(d).update||l(d).delete?(r(),g(c,{key:0,field:"id",title:"\u64CD\u4F5C",width:"300",fixed:"right"},{default:a(({row:o})=>[l(d).update?(r(),m(j,{key:0},[o.taskState==1?(r(),m("a",{key:0,href:"javascript:void(0)",onClick:v=>s.stopTimdTask(o.id)},"\u505C\u6B62",8,X)):(r(),m("a",{key:1,href:"javascript:void(0)",onClick:v=>s.startTimdTask(o.id)},"\u542F\u52A8",8,Y))],64)):f("",!0),t(C,{type:"vertical"}),l(d).update?(r(),m("a",{key:1,href:"javascript:void(0)",onClick:v=>s.execTimedTask(o.id)},"\u7ACB\u5373\u53D1\u9001",8,Z)):f("",!0),t(C,{type:"vertical"}),l(d).update?(r(),m("a",{key:2,href:"javascript:void(0)",onClick:v=>s.showLog(o.id)},"\u67E5\u770B\u65E5\u5FD7",8,ee)):f("",!0),t(C,{type:"vertical"}),l(d).update?(r(),m("a",{key:3,href:"javascript:void(0)",onClick:v=>s.openForm(o.id)},"\u7F16\u8F91",8,te)):f("",!0),t(C,{type:"vertical"}),l(d).delete?(r(),g($,{key:4,title:"\u60A8\u786E\u5B9A\u8981\u5220\u9664\u5417?",onConfirm:v=>s.deleteList(o.id),okText:"\u786E\u5B9A",cancelText:"\u53D6\u6D88"},{default:a(()=>[ne]),_:2},1032,["onConfirm"])):f("",!0)]),_:1})):f("",!0)]),_:1},8,["tableData","onOnChange"]),t(K,{ref_key:"refForm",ref:L,onOnSuccess:e[6]||(e[6]=()=>s.findList())},null,512),t(M,{visible:b.value,"onUpdate:visible":e[7]||(e[7]=o=>b.value=o),ref_key:"refCdrawer",ref:O},null,8,["visible"])])}}});export{ce as default};