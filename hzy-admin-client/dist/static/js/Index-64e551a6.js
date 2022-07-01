import{b as $,r as B,a as L,i as R,I as V,o as j,c as i,j as m,d as b,f as a,w as n,e as S,l,q as v,A as y,C as _,n as p,t as N}from"./index-4af06715.js";import P from"./List-5dba4a53.js";import{I as U,s as h}from"./Info-a794b2fc.js";const z=p("\u67E5\u8BE2"),A=p("\u91CD\u7F6E"),M=p(" \u65B0\u5EFA "),E=p(" \u6279\u91CF\u5220\u9664 "),q=p("\u91CD\u7F6E"),G=p(" \u68C0\u7D22 "),H=["onClick"],J=S("a",{class:"text-danger"},"\u5220\u9664",-1),Q={name:"system_dictionary"},ee=Object.assign(Q,{setup(W){const w=$(),t=B({search:{state:!1,fieldCount:2,vm:{name:null,parentId:null}},loading:!1,pageSizeOptions:[10,20,50,100,500,1e3],rows:10,page:1,total:0,data:[],tree:{data:[],expandedKeys:[],autoExpandParent:!0,checkedKeys:[],selectedKeys:[],loadingTree:!1}}),k=L(null),K=L(null),f=w.getPowerByMenuId(R.currentRoute.value.meta.menuId),o={onChange(s){const{currentPage:e,pageSize:d}=s;t.page=e==0?1:e,t.rows=d,o.findList()},onResetSearch(){t.page=1;let s=t.search.vm;for(let e in s)e!="parentId"&&(s[e]=null);o.findList()},findList(){t.loading=!0,h.findList(t.rows,t.page,t.search.vm).then(s=>{let e=s.data;t.loading=!1,t.page=e.page,t.rows=e.size,t.total=e.total,t.data=e.dataSource})},deleteList(s){let e=[];s?e.push(s):e=K.value.getCheckboxRecords().map(d=>d.id),h.deleteList(e).then(d=>{d.code==1&&(N.message("\u5220\u9664\u6210\u529F!","\u6210\u529F"),o.getDictionaryTree(),o.findList())})},openForm(s){k.value.openForm({visible:!0,key:s,parentId:t.search.vm.parentId})},onSaveSuccess(){o.getDictionaryTree(),o.findList()},getDictionaryTree(){t.tree.loadingTree=!0,h.getDictionaryTree().then(s=>{if(t.tree.loadingTree=!1,s.code!=1)return;let e=s.data;t.tree.data=e})},getFirst(){t.tree.selectedKeys=[]}};return V(()=>t.tree.selectedKeys,s=>{t.search.vm.parentId=s.length>0?s[0]:null,o.findList()}),j(()=>{o.getDictionaryTree(),o.findList()}),(s,e)=>{const d=i("a-tree"),I=i("a-spin"),D=i("a-card"),g=i("a-col"),C=i("a-input"),u=i("a-button"),x=i("a-row"),T=i("a-popconfirm"),c=i("vxe-column"),F=i("a-divider");return m(),b("div",null,[a(x,{gutter:[15,15]},{default:n(()=>[a(g,{xs:24,sm:12,md:12,lg:5,xl:5},{default:n(()=>[a(D,{title:"\u6570\u636E\u5B57\u5178\u6811",class:"w100 mb-15"},{extra:n(()=>[S("a",{href:"javascript:void(0)",onClick:e[0]||(e[0]=(...r)=>o.getFirst&&o.getFirst(...r))},"\u67E5\u770B\u4E00\u7EA7")]),default:n(()=>[a(I,{spinning:l(t).tree.loadingTree},{default:n(()=>[a(d,{selectedKeys:l(t).tree.selectedKeys,"onUpdate:selectedKeys":e[1]||(e[1]=r=>l(t).tree.selectedKeys=r),"tree-data":l(t).tree.data},null,8,["selectedKeys","tree-data"])]),_:1},8,["spinning"])]),_:1})]),_:1}),a(g,{xs:24,sm:12,md:12,lg:19,xl:19},{default:n(()=>[a(P,{ref:"refList",tableData:l(t),onOnChange:o.onChange},{search:n(()=>[a(x,{gutter:[15,15]},{default:n(()=>[a(g,{xs:24,sm:12,md:8,lg:6,xl:4},{default:n(()=>[a(C,{value:l(t).search.vm.name,"onUpdate:value":e[2]||(e[2]=r=>l(t).search.vm.name=r),placeholder:"\u540D\u79F0"},null,8,["value"])]),_:1}),a(g,{xs:24,sm:12,md:8,lg:6,xl:4,style:{float:"right"}},{default:n(()=>[a(u,{type:"primary",class:"mr-15",onClick:o.findList},{default:n(()=>[z]),_:1},8,["onClick"]),a(u,{class:"mr-15",onClick:o.onResetSearch},{default:n(()=>[A]),_:1},8,["onClick"])]),_:1})]),_:1})]),"toolbar-left":n(()=>[l(f).insert?(m(),v(u,{key:0,type:"primary",onClick:e[3]||(e[3]=r=>o.openForm())},{icon:n(()=>[a(y,{name:"PlusOutlined"})]),default:n(()=>[M]),_:1})):_("",!0),l(f).delete?(m(),v(T,{key:1,title:"\u60A8\u786E\u5B9A\u8981\u5220\u9664\u5417?",onConfirm:e[4]||(e[4]=r=>o.deleteList()),okText:"\u786E\u5B9A",cancelText:"\u53D6\u6D88"},{default:n(()=>[a(u,{type:"danger"},{icon:n(()=>[a(y,{name:"DeleteOutlined"})]),default:n(()=>[E]),_:1})]),_:1})):_("",!0)]),"toolbar-right":n(()=>[a(C,{value:l(t).search.vm.name,"onUpdate:value":e[5]||(e[5]=r=>l(t).search.vm.name=r),placeholder:"\u540D\u79F0",onKeyup:o.findList},null,8,["value","onKeyup"]),a(u,{onClick:o.onResetSearch},{default:n(()=>[q]),_:1},8,["onClick"]),l(f).search?(m(),v(u,{key:0,onClick:e[6]||(e[6]=r=>l(t).search.state=!l(t).search.state)},{icon:n(()=>[a(y,{name:l(t).search.state?"UpOutlined":"DownOutlined"},null,8,["name"])]),default:n(()=>[G]),_:1})):_("",!0)]),"table-col-default":n(()=>[a(c,{field:"sort",title:"\u5E8F\u53F7"}),a(c,{field:"code",title:"\u7F16\u53F7"}),a(c,{field:"name",title:"\u5206\u7EC4\u540D\u79F0/\u952E"}),a(c,{field:"value",title:"\u503C"}),a(c,{field:"lastModificationTime",title:"\u66F4\u65B0\u65F6\u95F4"}),a(c,{field:"creationTime",title:"\u521B\u5EFA\u65F6\u95F4"}),a(c,{field:"id",title:"\u64CD\u4F5C"},{default:n(({row:r})=>[l(f).update?(m(),b("a",{key:0,href:"javascript:void(0)",onClick:O=>o.openForm(r.id)},"\u7F16\u8F91",8,H)):_("",!0),a(F,{type:"vertical"}),l(f).delete?(m(),v(T,{key:1,title:"\u60A8\u786E\u5B9A\u8981\u5220\u9664\u5417?",onConfirm:O=>o.deleteList(r.id),okText:"\u786E\u5B9A",cancelText:"\u53D6\u6D88"},{default:n(()=>[J]),_:2},1032,["onConfirm"])):_("",!0)]),_:1})]),_:1},8,["tableData","onOnChange"]),a(U,{ref_key:"refForm",ref:k,onOnSuccess:e[7]||(e[7]=()=>o.onSaveSuccess())},null,512)]),_:1})]),_:1})])}}});export{ee as default};
