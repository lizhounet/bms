import{p as x,b as M,r as j,a as L,i as A,o as q,c as r,j as g,d as E,L as G,M as H,l as o,f as e,w as l,q as y,A as v,v as k,n as u,k as z,e as O,t as T,aT as K}from"./index-4ae57506.js";import Q from"./ColumnIndex-1ec999a2.js";import{c as W}from"./CodeGeneration-455f4456.js";import"./CodeLoadToProject-c756f7cc.js";import"./MdEditorShowCode-7883c543.js";const C="admin/LowCodeTable";var N={findList(m,w,t={}){return x(`${C}/findList/${m}/${w}`,t,!1)},deleteList(m){return m&&m.length===0?tools.message("\u8BF7\u9009\u62E9\u8981\u5220\u9664\u7684\u6570\u636E!","\u8B66\u544A"):x(`${C}/deleteList`,m,!1)},synchronization(){return x(`${C}/synchronization`,null,!1)},change(m){return x(`${C}/change`,m,!1)}};const X=u("\u67E5\u8BE2"),Y=u("\u91CD\u7F6E"),Z=u(" \u68C0\u7D22 "),ee=u(" \u540C\u6B65\u8868 "),te=u(" \u63D0\u4EA4\u66F4\u6539 "),ae=u(" \u6279\u91CF\u5220\u9664 "),le=u(" \u4E0B\u8F7D\u6570\u636E\u5E93\u8868\u8BBE\u8BA1 "),ne=["onClick"],oe=O("a",{class:"text-danger"},"\u5220\u9664",-1),ie={name:"LowCode"},me=Object.assign(ie,{setup(m){const w=M(),t=j({table:{search:{state:!1,vm:{tableName:null,entityName:null,displayName:null}},loading:!1,pageSizeOptions:[10,20,50,100,500,1e3],rows:10,page:1,total:0,data:[]},visible:!1,row:{}}),P=L(null),$=L(null),D=L(null),b=w.getPowerByMenuId(A.currentRoute.value.meta.menuId),s={onChange(i){const{currentPage:a,pageSize:d}=i;t.table.page=a==0?1:a,t.table.rows=d,s.findList()},onResetSearch(){t.table.page=1;let i=t.table.search.vm;for(let a in i)i[a]=null;s.findList()},findList(){t.table.loading=!0,N.findList(t.table.rows,t.table.page,t.table.search.vm).then(i=>{let a=i.data;t.table.loading=!1,t.table.page=a.page,t.table.rows=a.size,t.table.total=a.total,t.table.data=a.dataSource})},deleteList(i){let a=[];i?a.push(i):a=$.value.getCheckboxRecords().map(d=>d.id),N.deleteList(a).then(d=>{d.code==1&&(T.message("\u5220\u9664\u6210\u529F!","\u6210\u529F"),s.findList())})},openForm(i){P.value.openForm({visible:!0,key:i})},synchronization(){N.synchronization().then(i=>{T.message("\u540C\u6B65\u6210\u529F!","\u6210\u529F"),s.findList()})},change(){console.log(t.table.data),N.change(t.table.data).then(i=>{T.message("\u6570\u636E\u53D8\u66F4\u6210\u529F!","\u6210\u529F"),s.findList()})},loadColumnIndex(i){t.visible=!0,t.row=i,K(()=>{D.value.loadData(i)})},createDataDictionary(){W.createDataDictionary()}};return q(()=>{s.findList()}),(i,a)=>{const d=r("a-input"),_=r("a-col"),p=r("a-button"),S=r("a-row"),U=r("a-card"),h=r("a-popconfirm"),I=r("a-space"),c=r("vxe-column"),B=r("a-divider"),R=r("vxe-table"),V=r("vxe-pager"),F=r("a-spin"),J=r("a-drawer");return g(),E("div",null,[G(e(U,{class:"mb-15"},{default:l(()=>[e(S,{gutter:[15,15]},{default:l(()=>[e(_,{xs:24,sm:12,md:8,lg:6,xl:4},{default:l(()=>[e(d,{value:o(t).table.search.vm.tableName,"onUpdate:value":a[0]||(a[0]=n=>o(t).table.search.vm.tableName=n),placeholder:"\u8868\u540D\u79F0"},null,8,["value"])]),_:1}),e(_,{xs:24,sm:12,md:8,lg:6,xl:4},{default:l(()=>[e(d,{value:o(t).table.search.vm.entityName,"onUpdate:value":a[1]||(a[1]=n=>o(t).table.search.vm.entityName=n),placeholder:"\u5B9E\u4F53\u540D\u79F0"},null,8,["value"])]),_:1}),e(_,{xs:24,sm:12,md:8,lg:6,xl:4},{default:l(()=>[e(d,{value:o(t).table.search.vm.displayName,"onUpdate:value":a[2]||(a[2]=n=>o(t).table.search.vm.displayName=n),placeholder:"\u663E\u793A\u540D\u79F0"},null,8,["value"])]),_:1}),e(_,{xs:24,sm:12,md:8,lg:6,xl:4,style:{float:"right"}},{default:l(()=>[e(p,{type:"primary",class:"mr-15",onClick:s.findList},{default:l(()=>[X]),_:1},8,["onClick"]),e(p,{class:"mr-15",onClick:s.onResetSearch},{default:l(()=>[Y]),_:1},8,["onClick"])]),_:1})]),_:1})]),_:1},512),[[H,o(t).table.search.state]]),e(U,null,{default:l(()=>[e(S,{gutter:[15,15]},{default:l(()=>[e(_,{xs:24,sm:24,md:12,lg:12,xl:12},{default:l(()=>[e(I,{size:15},{default:l(()=>[o(b).search?(g(),y(p,{key:0,onClick:a[3]||(a[3]=n=>o(t).table.search.state=!o(t).table.search.state)},{icon:l(()=>[e(v,{name:o(t).table.search.state?"UpOutlined":"DownOutlined"},null,8,["name"])]),default:l(()=>[Z]),_:1})):k("",!0),e(h,{title:"\u60A8\u786E\u5B9A\u8981\u66F4\u65B0\u8868\u5417?\u53EF\u80FD\u4F1A\u5BFC\u81F4\u6570\u636E\u4E22\u5931",onConfirm:a[4]||(a[4]=n=>s.synchronization()),okText:"\u786E\u5B9A",cancelText:"\u53D6\u6D88"},{default:l(()=>[e(p,{type:"primary"},{icon:l(()=>[e(v,{name:"ReloadOutlined"})]),default:l(()=>[ee]),_:1})]),_:1}),e(h,{title:"\u60A8\u786E\u5B9A\u8981\u63D0\u4EA4\u66F4\u6539?",onConfirm:a[5]||(a[5]=n=>s.change()),okText:"\u786E\u5B9A",cancelText:"\u53D6\u6D88"},{default:l(()=>[e(p,{type:"primary"},{icon:l(()=>[e(v,{name:"PlusOutlined"})]),default:l(()=>[te]),_:1})]),_:1}),o(b).delete?(g(),y(h,{key:1,title:"\u60A8\u786E\u5B9A\u8981\u5220\u9664\u5417?",onConfirm:a[6]||(a[6]=n=>s.deleteList()),okText:"\u786E\u5B9A",cancelText:"\u53D6\u6D88"},{default:l(()=>[e(p,{type:"danger"},{icon:l(()=>[e(v,{name:"DeleteOutlined"})]),default:l(()=>[ae]),_:1})]),_:1})):k("",!0),o(b).search?(g(),y(p,{key:2,onClick:a[7]||(a[7]=n=>s.createDataDictionary())},{icon:l(()=>[e(v,{name:"DownloadOutlined"})]),default:l(()=>[le]),_:1})):k("",!0)]),_:1})]),_:1}),e(_,{xs:24,sm:24,md:12,lg:12,xl:12,class:"text-right"})]),_:1}),e(F,{spinning:o(t).table.loading},{default:l(()=>[e(R,{class:"mt-15",ref_key:"refTable",ref:$,size:"medium",border:"",stripe:"",data:o(t).table.data,"row-config":{isCurrent:!0,isHover:!0},"column-config":{isCurrent:!0,resizable:!0},"checkbox-config":{highlight:!0},"edit-config":{trigger:"click",mode:"cell"}},{default:l(()=>[e(c,{type:"seq",width:"60"}),e(c,{type:"checkbox",width:"60"}),e(c,{field:"tableName",title:"\u8868\u540D\u79F0"}),e(c,{field:"displayName",title:"\u663E\u793A\u540D\u79F0","edit-render":{}},{default:l(({row:n})=>[u(z(n.displayName),1)]),edit:l(({row:n})=>[e(d,{value:n.displayName,"onUpdate:value":f=>n.displayName=f,placeholder:"\u663E\u793A\u540D\u79F0"},null,8,["value","onUpdate:value"])]),_:1}),e(c,{field:"entityName",title:"\u5B9E\u4F53\u540D\u79F0","edit-render":{}},{default:l(({row:n})=>[u(z(n.entityName),1)]),edit:l(({row:n})=>[e(d,{value:n.entityName,"onUpdate:value":f=>n.entityName=f,placeholder:"\u5B9E\u4F53\u540D\u79F0"},null,8,["value","onUpdate:value"])]),_:1}),e(c,{field:"remark",title:"\u5907\u6CE8","edit-render":{}},{default:l(({row:n})=>[u(z(n.remark),1)]),edit:l(({row:n})=>[e(d,{value:n.remark,"onUpdate:value":f=>n.remark=f,placeholder:"\u5907\u6CE8"},null,8,["value","onUpdate:value"])]),_:1}),e(c,{field:"lastModificationTime",title:"\u66F4\u65B0\u65F6\u95F4",width:"120px"}),e(c,{field:"creationTime",title:"\u521B\u5EFA\u65F6\u95F4",width:"120px"}),e(c,{field:"id",title:"\u64CD\u4F5C",width:"120px"},{default:l(({row:n})=>[O("a",{href:"javascript:void(0)",onClick:f=>s.loadColumnIndex(n)}," \u914D\u7F6E ",8,ne),e(B,{type:"vertical"}),o(b).delete?(g(),y(h,{key:0,title:"\u60A8\u786E\u5B9A\u8981\u5220\u9664\u5417?",onConfirm:f=>s.deleteList(n.id),okText:"\u786E\u5B9A",cancelText:"\u53D6\u6D88"},{default:l(()=>[oe]),_:2},1032,["onConfirm"])):k("",!0)]),_:1})]),_:1},8,["data"]),e(V,{background:"","current-page":o(t).table.page,"onUpdate:current-page":a[8]||(a[8]=n=>o(t).table.page=n),"page-size":o(t).table.rows,"onUpdate:page-size":a[9]||(a[9]=n=>o(t).table.rows=n),total:o(t).table.total,"page-sizes":o(t).table.pageSizeOptions,layouts:["PrevJump","PrevPage","JumpNumber","NextPage","NextJump","Sizes","FullJump","Total"],onPageChange:s.onChange},null,8,["current-page","page-size","total","page-sizes","onPageChange"])]),_:1},8,["spinning"])]),_:1}),e(J,{width:"90%",title:"[ "+o(t).row.tableName+" - "+o(t).row.displayName+" ] \u914D\u7F6E",placement:"right",visible:o(t).visible,onClose:a[10]||(a[10]=n=>o(t).visible=!o(t).visible)},{default:l(()=>[e(Q,{ref_key:"refColumnIndex",ref:D},null,512)]),_:1},8,["title","visible"])])}}});export{me as default};
