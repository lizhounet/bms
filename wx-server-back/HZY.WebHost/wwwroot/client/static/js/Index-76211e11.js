import{b as z,r as B,a as E,i as I,o as N,c as r,j as u,d as w,K as V,L as A,l as a,f as e,w as t,q as g,A as x,z as p,n as f,k as S,aW as D,F as M,e as k,aS as P,t as U}from"./index-b138b776.js";import{_ as q,s as O}from"./Info-019396fa.js";import"./AppIconList-d1049ab7.js";const H=f("\u67E5\u8BE2"),K=f("\u91CD\u7F6E"),W=f(" \u65B0\u5EFA "),G=f(" \u6279\u91CF\u5220\u9664 "),J=f(" \u68C0\u7D22 "),Q=["onClick"],X=["onClick"],Z=k("a",{class:"text-danger"},"\u5220\u9664",-1),ee={name:"system_menu"},se=Object.assign(ee,{setup(te){const Y=z(),o=B({search:{state:!1,fieldCount:2,vm:{name:null}},loading:!1,data:[],expandRows:[]}),y=E(null),_=E(null),m=Y.getPowerByMenuId(I.currentRoute.value.meta.menuId),l={onChange(s){const{currentPage:n,pageSize:c}=s;o.page=n==0?1:n,o.rows=c,l.findList()},onResetSearch(){o.page=1;let s=o.search.vm;for(let n in s)s[n]=null;l.findList()},findList(){o.loading=!0,O.getAll(o.search.vm).then(s=>{let n=s.data;o.loading=!1,o.data=n,P(()=>l.recoveryOpenRows())})},deleteList(s){let n=[];s?n.push(s):n=_.value.getCheckboxRecords().map(c=>c.id),O.deleteList(n).then(c=>{c.code==1&&(U.message("\u5220\u9664\u6210\u529F!","\u6210\u529F"),l.findList())})},openForm(s,n){y.value.openForm({visible:!0,key:s,parentId:n})},onToggleTreeExpand(){o.expandRows=_.value.getTreeExpandRecords()},recoveryOpenRows(){var s=o.expandRows;s.length>0&&(_.value.setTreeExpand(o.data[1],!0),s.forEach(n=>{_.value.setTreeExpand(o.data.filter(c=>c.id==n.id),!0)}))}};return N(()=>{l.findList()}),(s,n)=>{const c=r("a-input"),v=r("a-col"),h=r("a-button"),T=r("a-row"),C=r("a-card"),b=r("a-popconfirm"),L=r("a-space"),d=r("vxe-column"),F=r("a-divider"),$=r("vxe-table"),j=r("a-spin");return u(),w("div",null,[V(e(C,{class:"mb-15"},{default:t(()=>[e(T,{gutter:[15,15]},{default:t(()=>[e(v,{xs:24,sm:12,md:8,lg:6,xl:4},{default:t(()=>[e(c,{value:a(o).search.vm.name,"onUpdate:value":n[0]||(n[0]=i=>a(o).search.vm.name=i),placeholder:"\u540D\u79F0"},null,8,["value"])]),_:1}),e(v,{xs:24,sm:12,md:8,lg:6,xl:4,style:{float:"right"}},{default:t(()=>[e(h,{type:"primary",class:"mr-15",onClick:l.findList},{default:t(()=>[H]),_:1},8,["onClick"]),e(h,{class:"mr-15",onClick:l.onResetSearch},{default:t(()=>[K]),_:1},8,["onClick"])]),_:1})]),_:1})]),_:1},512),[[A,a(o).search.state]]),e(C,null,{default:t(()=>[e(T,{gutter:[15,15]},{default:t(()=>[e(v,{xs:24,sm:24,md:12,lg:12,xl:12},{default:t(()=>[e(L,{size:15},{default:t(()=>[a(m).insert?(u(),g(h,{key:0,type:"primary",onClick:n[1]||(n[1]=i=>l.openForm())},{icon:t(()=>[e(x,{name:"PlusOutlined"})]),default:t(()=>[W]),_:1})):p("",!0),a(m).delete?(u(),g(b,{key:1,title:"\u60A8\u786E\u5B9A\u8981\u5220\u9664\u5417?",onConfirm:n[2]||(n[2]=i=>l.deleteList()),okText:"\u786E\u5B9A",cancelText:"\u53D6\u6D88"},{default:t(()=>[e(h,{type:"danger"},{icon:t(()=>[e(x,{name:"DeleteOutlined"})]),default:t(()=>[G]),_:1})]),_:1})):p("",!0)]),_:1})]),_:1}),e(v,{xs:24,sm:24,md:12,lg:12,xl:12,class:"text-right",style:{display:"inline-flex","justify-content":"end"}},{default:t(()=>[e(L,{size:15},{default:t(()=>[a(m).search?(u(),g(h,{key:0,onClick:n[3]||(n[3]=i=>a(o).search.state=!a(o).search.state)},{icon:t(()=>[e(x,{name:a(o).search.state?"UpOutlined":"DownOutlined"},null,8,["name"])]),default:t(()=>[J]),_:1})):p("",!0)]),_:1})]),_:1})]),_:1}),e(j,{spinning:a(o).loading},{default:t(()=>[e($,{class:"mt-15",ref_key:"refTable",ref:_,border:"",stripe:"",data:a(o).data,"row-config":{isCurrent:!0,isHover:!0},"column-config":{isCurrent:!0,resizable:!0},"checkbox-config":{highlight:!0},"tree-config":{transform:!0,rowField:"id",parentField:"parentId"},onToggleTreeExpand:l.onToggleTreeExpand},{default:t(()=>[e(d,{type:"checkbox",width:"40"}),e(d,{field:"name",title:"\u540D\u79F0","show-overflow":"","tree-node":"",width:"200"}),e(d,{field:"icon",title:"\u56FE\u6807",width:"60"},{default:t(({row:i})=>[e(x,{name:i.icon},null,8,["name"])]),_:1}),e(d,{field:"number",title:"\u7F16\u53F7",width:"80"}),e(d,{field:"componentName",title:"\u7EC4\u4EF6\u540D\u79F0","show-overflow":"","min-width":"220"}),e(d,{field:"url",title:"\u7EC4\u4EF6\u5730\u5740","show-overflow":"",width:"250"}),e(d,{field:"router",title:"\u8DEF\u7531\u5730\u5740","show-overflow":"",width:"250"}),e(d,{field:"lastModificationTime",title:"\u66F4\u65B0\u65F6\u95F4",width:"120"},{default:t(({row:i})=>[f(S(a(D)(i.lastModificationTime).format("YYYY-MM-DD")),1)]),_:1}),e(d,{field:"creationTime",title:"\u521B\u5EFA\u65F6\u95F4",width:"120"},{default:t(({row:i})=>[f(S(a(D)(i.creationTime).format("YYYY-MM-DD")),1)]),_:1}),e(d,{field:"id",title:"\u64CD\u4F5C",width:"200"},{default:t(({row:i})=>[a(m).insert?(u(),w(M,{key:0},[k("a",{href:"javascript:void(0)",onClick:R=>l.openForm(null,i.id)},"\u65B0\u5EFA",8,Q),e(F,{type:"vertical"})],64)):p("",!0),a(m).update?(u(),w(M,{key:1},[k("a",{href:"javascript:void(0)",onClick:R=>l.openForm(i.id,i.parentId)},"\u7F16\u8F91",8,X),e(F,{type:"vertical"})],64)):p("",!0),a(m).delete?(u(),g(b,{key:2,title:"\u60A8\u786E\u5B9A\u8981\u5220\u9664\u5417?",onConfirm:R=>l.deleteList(i.id),okText:"\u786E\u5B9A",cancelText:"\u53D6\u6D88"},{default:t(()=>[Z]),_:2},1032,["onConfirm"])):p("",!0)]),_:1})]),_:1},8,["data","onToggleTreeExpand"])]),_:1},8,["spinning"])]),_:1}),e(q,{ref_key:"refForm",ref:y,onOnSuccess:n[4]||(n[4]=()=>l.findList())},null,512)])}}});export{se as default};
