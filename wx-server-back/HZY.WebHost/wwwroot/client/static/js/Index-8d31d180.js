import{_ as q,b as H,r as J,J as G,a as z,i as Q,H as N,o as W,c as i,j as d,d as p,f as o,w as a,e as $,l,q as _,A as x,z as c,F as B,C as T,n as f,g as X,h as Y,aV as F,t as S,aS as Z,k as ee}from"./index-997773e6.js";import te from"./List-c3bf3945.js";import ae from"./Info-93af3d49.js";import{o as ne}from"./organizationService-32f8eaf2.js";const oe=C=>(X("data-v-bb6da1d0"),C=C(),Y(),C),se=f("\u67E5\u8BE2"),le=f("\u91CD\u7F6E"),re=f(" \u65B0\u5EFA "),de=f(" \u6279\u91CF\u5220\u9664 "),ie=f(" \u5E26\u56DE\u6570\u636E "),ce=f("\u5BFC\u51FA Excel"),ue=f(" \u66F4\u591A\u64CD\u4F5C "),pe=f("\u91CD\u7F6E"),fe=f(" \u68C0\u7D22 "),me={key:0,style:{color:"green"}},_e={key:1,style:{color:"gray"}},ge={key:2,style:{color:"red"}},he=["onClick"],ke=oe(()=>$("a",{class:"text-danger"},"\u5220\u9664",-1)),ve={name:"system_user"},ye=Object.assign(ve,{props:{isFindBack:{type:Boolean,default(){return!1}},defaultRowIds:Array,type:{type:Boolean,default(){return!0}}},emits:["onChange"],setup(C,{emit:U}){const g=C,D=H(),t=J({search:{state:!1,vm:{name:null,loginName:null,organizationId:null}},loading:!1,pageSizeOptions:[10,20,50,100,500,1e3],rows:10,page:1,total:0,columns:[],data:[],tree:{data:[],expandedKeys:[],selectedKeys:[],loadingTree:!1},findBack:{defaultRowIds:G(()=>g.defaultRowIds)}}),K=z(null),h=z(null),k=D.getPowerByMenuId(Q.currentRoute.value.meta.menuId),r={onChange(s){const{currentPage:e,pageSize:u}=s;t.page=e==0?1:e,t.rows=u,r.findList()},onResetSearch(){t.page=1;let s=t.search.vm;for(let e in s)s[e]=null;r.findList()},findList(){t.loading=!0,F.findList(t.rows,t.page,t.search.vm).then(s=>{let e=s.data;t.loading=!1,t.page=e.page,t.rows=e.size,t.total=e.total,t.columns=e.columns,t.data=e.dataSource,r.findBack.setCheckboxRow()})},deleteList(s){let e=[];s?e.push(s):e=h.value.table.getCheckboxRecords().map(u=>u.id),F.deleteList(e).then(u=>{u.code==1&&(S.message("\u5220\u9664\u6210\u529F!","\u6210\u529F"),r.findList())})},openForm(s){if(!s&&!t.search.vm.organizationId)return S.message("\u8BF7\u9009\u62E9\u7EC4\u7EC7!","\u8B66\u544A");K.value.openForm({visible:!0,key:s,organizationId:t.search.vm.organizationId})},exportExcel(){F.exportExcel(t.search.vm)},sysOrganizationTree(){t.tree.loadingTree=!0,ne.sysOrganizationTree().then(s=>{t.tree.loadingTree=!1;let e=s.data;t.tree.data=e.rows,t.tree.expandedKeys=e.expandedRowKeys,r.findList()})},getFirst(){t.tree.selectedKeys=[]},findBack:{initRows(){!g.isFindBack||N(()=>g.defaultRowIds,s=>{r.findBack.setCheckboxRow()})},setCheckboxRow(){!g.isFindBack||(h.value.table.setAllCheckboxRow(!1),h.value.table.setCheckboxRow(r.findBack.getRowsByIds(t.findBack.defaultRowIds),!0))},onChange(){if(!!g.isFindBack){var s=h.value.table.getCheckboxRecords();if(g.type&&s.length>1)return S.message("\u53EA\u80FD\u9009\u62E9\u4E00\u6761\u6570\u636E!","\u8B66\u544A");U("onChange",h.value.table.getCheckboxRecords())}},getRowsByIds(s){if(!!g.isFindBack){var e=[],u=t.data;for(let b=0;b<u.length;b++){const w=u[b];s.filter(v=>v==w.id).length>0&&e.push(w)}return e}}}};return r.findBack.initRows(),N(()=>t.tree.selectedKeys,s=>{t.search.vm.organizationId=s.length>0?s[0]:null,r.findList()}),W(()=>{r.sysOrganizationTree()}),(s,e)=>{const u=i("a-tree"),b=i("a-spin"),w=i("a-card"),v=i("a-col"),R=i("a-input"),m=i("a-button"),L=i("a-row"),O=i("a-popconfirm"),V=i("a-menu-item"),A=i("a-menu"),E=i("a-dropdown"),j=i("a-checkbox"),P=i("a-popover"),I=i("vxe-column"),M=i("a-divider");return d(),p("div",null,[o(L,{gutter:[15,15]},{default:a(()=>[o(v,{xs:24,sm:12,md:12,lg:5,xl:5},{default:a(()=>[o(w,{title:"\u7EC4\u7EC7\u67B6\u6784",class:"w100 mb-15 min-height"},{extra:a(()=>[$("a",{href:"javascript:void(0)",onClick:e[0]||(e[0]=(...n)=>r.getFirst&&r.getFirst(...n))},"\u67E5\u770B\u4E00\u7EA7")]),default:a(()=>[o(b,{spinning:l(t).tree.loadingTree},{default:a(()=>[o(u,{expandedKeys:l(t).tree.expandedKeys,"onUpdate:expandedKeys":e[1]||(e[1]=n=>l(t).tree.expandedKeys=n),selectedKeys:l(t).tree.selectedKeys,"onUpdate:selectedKeys":e[2]||(e[2]=n=>l(t).tree.selectedKeys=n),"tree-data":l(t).tree.data},null,8,["expandedKeys","selectedKeys","tree-data"])]),_:1},8,["spinning"])]),_:1})]),_:1}),o(v,{xs:24,sm:12,md:12,lg:19,xl:19},{default:a(()=>[o(te,{ref_key:"refList",ref:h,tableData:l(t),onOnChange:r.onChange},{search:a(()=>[o(L,{gutter:[15,15]},{default:a(()=>[o(v,{xs:24,sm:12,md:8,lg:6,xl:6},{default:a(()=>[o(R,{value:l(t).search.vm.name,"onUpdate:value":e[3]||(e[3]=n=>l(t).search.vm.name=n),placeholder:"\u771F\u5B9E\u540D\u79F0"},null,8,["value"])]),_:1}),o(v,{xs:24,sm:12,md:8,lg:6,xl:6},{default:a(()=>[o(R,{value:l(t).search.vm.loginName,"onUpdate:value":e[4]||(e[4]=n=>l(t).search.vm.loginName=n),placeholder:"\u8D26\u6237\u540D\u79F0"},null,8,["value"])]),_:1}),o(v,{xs:24,sm:12,md:8,lg:6,xl:6,style:{float:"right"}},{default:a(()=>[o(m,{type:"primary",class:"mr-15",onClick:r.findList},{default:a(()=>[se]),_:1},8,["onClick"]),o(m,{class:"mr-15",onClick:r.onResetSearch},{default:a(()=>[le]),_:1},8,["onClick"])]),_:1})]),_:1})]),"toolbar-left":a(()=>[l(k).insert&&!s.$props.isFindBack?(d(),_(m,{key:0,type:"primary",onClick:e[5]||(e[5]=n=>r.openForm())},{icon:a(()=>[o(x,{name:"PlusOutlined"})]),default:a(()=>[re]),_:1})):c("",!0),l(k).delete&&!s.$props.isFindBack?(d(),_(O,{key:1,title:"\u60A8\u786E\u5B9A\u8981\u5220\u9664\u5417?",onConfirm:e[6]||(e[6]=n=>r.deleteList()),okText:"\u786E\u5B9A",cancelText:"\u53D6\u6D88"},{default:a(()=>[o(m,{type:"danger"},{icon:a(()=>[o(x,{name:"DeleteOutlined"})]),default:a(()=>[de]),_:1})]),_:1})):c("",!0),s.$props.isFindBack?(d(),_(m,{key:2,type:"primary",onClick:e[7]||(e[7]=n=>r.findBack.onChange())},{icon:a(()=>[o(x,{name:"CheckOutlined"})]),default:a(()=>[ie]),_:1})):c("",!0),o(E,null,{overlay:a(()=>[o(A,null,{default:a(()=>[o(V,{key:"1",onClick:r.exportExcel},{default:a(()=>[ce]),_:1},8,["onClick"])]),_:1})]),default:a(()=>[o(m,null,{default:a(()=>[ue,o(x,{name:"DownOutlined"})]),_:1})]),_:1})]),"toolbar-right":a(()=>[o(R,{value:l(t).search.vm.name,"onUpdate:value":e[8]||(e[8]=n=>l(t).search.vm.name=n),placeholder:"\u540D\u79F0",onKeyup:r.findList},null,8,["value","onKeyup"]),o(m,{onClick:r.onResetSearch},{default:a(()=>[pe]),_:1},8,["onClick"]),l(k).search?(d(),_(m,{key:0,onClick:e[9]||(e[9]=n=>l(t).search.state=!l(t).search.state)},{icon:a(()=>[o(x,{name:l(t).search.state?"UpOutlined":"DownOutlined"},null,8,["name"])]),default:a(()=>[fe]),_:1})):c("",!0),o(P,null,{content:a(()=>[(d(!0),p(B,null,T(l(t).columns.filter(n=>n.fieldName.substr(0,1)!="_"),n=>(d(),p("div",null,[o(j,{checked:n.show,"onUpdate:checked":y=>n.show=y,onChange:e[10]||(e[10]=()=>Z(()=>h.value.table.refreshColumn()))},{default:a(()=>[f(ee(n.title),1)]),_:2},1032,["checked","onUpdate:checked"])]))),256))]),default:a(()=>[o(m,null,{default:a(()=>[o(x,{name:"BarsOutlined"})]),_:1})]),_:1})]),"table-col-default":a(()=>[(d(!0),p(B,null,T(l(t).columns.filter(n=>n.fieldName!="id"),n=>(d(),p(B,null,[n.fieldName=="userState"?(d(),_(I,{field:n.fieldName,title:n.title,visible:n.show,key:n.id},{default:a(({row:y})=>[y.userState==1?(d(),p("p",me,"\u5DF2\u6FC0\u6D3B")):c("",!0),y.userState==2?(d(),p("p",_e,"\u672A\u6FC0\u6D3B")):c("",!0),y.userState==3?(d(),p("p",ge,"\u5DF2\u505C\u7528")):c("",!0)]),_:2},1032,["field","title","visible"])):(d(),p(B,{key:1},[n.fieldName!="id"?(d(),_(I,{field:n.fieldName,title:n.title,visible:n.show,key:n.id},null,8,["field","title","visible"])):c("",!0)],64))],64))),256)),(l(k).update||l(k).delete)&&!s.$props.isFindBack?(d(),_(I,{key:0,field:"id",title:"\u64CD\u4F5C"},{default:a(({row:n})=>[l(k).update?(d(),p("a",{key:0,href:"javascript:void(0)",onClick:y=>r.openForm(n.id)},"\u7F16\u8F91",8,he)):c("",!0),o(M,{type:"vertical"}),l(k).delete?(d(),_(O,{key:1,title:"\u60A8\u786E\u5B9A\u8981\u5220\u9664\u5417?",onConfirm:y=>r.deleteList(n.id),okText:"\u786E\u5B9A",cancelText:"\u53D6\u6D88"},{default:a(()=>[ke]),_:2},1032,["onConfirm"])):c("",!0)]),_:1})):c("",!0)]),_:1},8,["tableData","onOnChange"])]),_:1})]),_:1}),o(ae,{ref_key:"refForm",ref:K,onOnSuccess:e[11]||(e[11]=()=>r.findList())},null,512)])}}});var Be=q(ye,[["__scopeId","data-v-bb6da1d0"]]);export{Be as default};
