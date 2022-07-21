import{b as N,r as O,a as S,i as R,o as V,c as i,j as c,d as g,K as $,L as E,l as s,f as e,w as t,q as m,A as D,z as f,n as d,k as F,aW as Y,e as U,aS as P,t as q}from"./index-eda3e6f0.js";import H from"./Info-90372ea3.js";import{o as A}from"./organizationService-d533f459.js";const K=d(" \u6B63\u5E38 "),W=d(" \u505C\u7528 "),G=d("\u67E5\u8BE2"),J=d("\u91CD\u7F6E"),Q=d(" \u68C0\u7D22 "),X=d(" \u65B0\u5EFA "),Z=d("\u6B63\u5E38"),ee=d("\u505C\u7528"),te=["onClick"],ae=["onClick"],oe=U("a",{class:"text-danger"},"\u5220\u9664",-1),ne={name:"system_organization"},de=Object.assign(ne,{setup(se){const M=N(),n=O({search:{state:!1,vm:{name:null,state:1}},loading:!1,data:[]}),k=S(null),x=S(null),_=M.getPowerByMenuId(R.currentRoute.value.meta.menuId),l={onResetSearch(){let r=n.search.vm;for(let a in r)r[a]=null;r.state=1,l.findList()},findList(){n.loading=!0,A.findList(n.search.vm).then(r=>{let a=r.data;n.loading=!1,n.data=a,P(()=>{l.setAllTreeExpand()})})},deleteList(r){let a=[];r&&a.push(r),A.deleteList(a).then(h=>{h.code==1&&(q.message("\u5220\u9664\u6210\u529F!","\u6210\u529F"),l.findList())})},openForm(r,a){k.value.openForm({visible:!0,key:r,parentId:a})},formatDate(r){return Y(r).format("YYYY-MM-DD")},setAllTreeExpand(){x.value.setAllTreeExpand(!0)}};return V(()=>{l.findList()}),(r,a)=>{const h=i("a-input"),p=i("a-col"),y=i("a-radio"),j=i("a-radio-group"),v=i("a-button"),C=i("a-row"),b=i("a-card"),z=i("a-space"),u=i("vxe-column"),T=i("a-tag"),L=i("a-divider"),B=i("a-popconfirm"),I=i("vxe-table");return c(),g("div",null,[$(e(b,{class:"mb-15"},{default:t(()=>[e(C,{gutter:[15,15]},{default:t(()=>[e(p,{xs:24,sm:12,md:8,lg:6,xl:4},{default:t(()=>[e(h,{value:s(n).search.vm.name,"onUpdate:value":a[0]||(a[0]=o=>s(n).search.vm.name=o),placeholder:"\u540D\u79F0"},null,8,["value"])]),_:1}),e(p,{xs:24,sm:12,md:8,lg:6,xl:4},{default:t(()=>[e(j,{value:s(n).search.vm.state,"onUpdate:value":a[1]||(a[1]=o=>s(n).search.vm.state=o)},{default:t(()=>[e(y,{value:1},{default:t(()=>[K]),_:1}),e(y,{value:2},{default:t(()=>[W]),_:1})]),_:1},8,["value"])]),_:1}),e(p,{xs:24,sm:12,md:8,lg:6,xl:4,style:{float:"right"}},{default:t(()=>[e(v,{type:"primary",class:"mr-15",onClick:l.findList},{default:t(()=>[G]),_:1},8,["onClick"]),e(v,{class:"mr-15",onClick:l.onResetSearch},{default:t(()=>[J]),_:1},8,["onClick"])]),_:1})]),_:1})]),_:1},512),[[E,s(n).search.state]]),e(b,null,{default:t(()=>[e(C,{gutter:[15,15]},{default:t(()=>[e(p,{xs:24,sm:24,md:12,lg:12,xl:12},{default:t(()=>[e(z,{size:15},{default:t(()=>[s(_).search?(c(),m(v,{key:0,onClick:a[2]||(a[2]=o=>s(n).search.state=!s(n).search.state)},{icon:t(()=>[e(D,{name:s(n).search.state?"UpOutlined":"DownOutlined"},null,8,["name"])]),default:t(()=>[Q]),_:1})):f("",!0),s(_).insert?(c(),m(v,{key:1,type:"primary",onClick:a[3]||(a[3]=o=>l.openForm())},{icon:t(()=>[e(D,{name:"PlusOutlined"})]),default:t(()=>[X]),_:1})):f("",!0)]),_:1})]),_:1})]),_:1}),e(I,{class:"mt-15",ref_key:"refTable",ref:x,border:"",stripe:"",data:s(n).data,"row-config":{isCurrent:!0,isHover:!0},"column-config":{isCurrent:!0,resizable:!0},"checkbox-config":{highlight:!0},"tree-config":{transform:!0,rowField:"id",parentField:"parentId"}},{default:t(()=>[e(u,{field:"name",title:"\u90E8\u95E8\u540D\u79F0","tree-node":""}),e(u,{field:"orderNumber",title:"\u6392\u5E8F\u53F7"}),e(u,{field:"levelCode",title:"\u7EA7\u522B\u7801"}),e(u,{field:"state",title:"\u72B6\u6001"},{default:t(({row:o})=>[o.state==1?(c(),m(T,{key:0,color:"success"},{default:t(()=>[Z]),_:1})):(c(),m(T,{key:1,color:"warning"},{default:t(()=>[ee]),_:1}))]),_:1}),e(u,{field:"lastModificationTime",title:"\u66F4\u65B0\u65F6\u95F4"},{default:t(({row:o})=>[d(F(l.formatDate(o.lastModificationTime)),1)]),_:1}),e(u,{field:"creationTime",title:"\u521B\u5EFA\u65F6\u95F4"},{default:t(({row:o})=>[d(F(l.formatDate(o.creationTime)),1)]),_:1}),e(u,{field:"id",title:"\u64CD\u4F5C"},{default:t(({row:o})=>[s(_).insert?(c(),g("a",{key:0,href:"javascript:void(0)",onClick:w=>l.openForm(null,o.id)},"\u65B0\u5EFA",8,te)):f("",!0),e(L,{type:"vertical"}),s(_).update?(c(),g("a",{key:1,href:"javascript:void(0)",onClick:w=>l.openForm(o.id)},"\u7F16\u8F91",8,ae)):f("",!0),e(L,{type:"vertical"}),s(_).delete?(c(),m(B,{key:2,title:"\u60A8\u786E\u5B9A\u8981\u5220\u9664\u5417?",onConfirm:w=>l.deleteList(o.id),okText:"\u786E\u5B9A",cancelText:"\u53D6\u6D88"},{default:t(()=>[oe]),_:2},1032,["onConfirm"])):f("",!0)]),_:1})]),_:1},8,["data"])]),_:1}),e(H,{ref_key:"formRef",ref:k,onOnSuccess:a[4]||(a[4]=()=>l.findList())},null,512)])}}});export{de as default};
