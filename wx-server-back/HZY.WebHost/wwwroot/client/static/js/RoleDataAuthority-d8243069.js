var E=Object.defineProperty;var _=Object.getOwnPropertySymbols;var I=Object.prototype.hasOwnProperty,F=Object.prototype.propertyIsEnumerable;var v=(s,n,e)=>n in s?E(s,n,{enumerable:!0,configurable:!0,writable:!0,value:e}):s[n]=e,K=(s,n)=>{for(var e in n||(n={}))I.call(n,e)&&v(s,e,n[e]);if(_)for(var e of _(n))F.call(n,e)&&v(s,e,n[e]);return s};import{p as m,t as g,s as A,aV as B,r as S,H as k,c as p,j as b,q as z,w as d,f as r,l as a,d as H,e as D,v as O,n as i}from"./index-703a0050.js";import{o as U}from"./organizationService-490aaa05.js";const h="admin/SysDataAuthority";var $={findList(s,n,e={}){return m(`${h}/findList/${s}/${n}`,e,!1)},deleteList(s){return console.log(s),s&&s.length===0?g.message("\u8BF7\u9009\u62E9\u8981\u5220\u9664\u7684\u6570\u636E!","\u8B66\u544A"):m(`${h}/deleteList`,s,!1)},findForm(s){return A(`${h}/findForm${s?"/"+s:""}`)},saveForm(s){return m(`${h}/saveForm`,s)},exportExcel(s){return B(`${h}/exportExcel`,s)},getDataAuthorityByRoleId(s){return A(`${h}/getDataAuthorityByRoleId/${s}`)}};const N=i("\u63D0\u4EA4"),R=i("\u5173\u95ED"),V=i("\u81EA\u5B9A\u4E49\u6743\u9650"),j=i("\u67E5\u770B\u6240\u6709\u6570\u636E"),q=i("\u4EC5\u67E5\u770B\u672C\u7EC4\u7EC7"),W=i("\u4EC5\u67E5\u770B\u672C\u7EC4\u7EC7\u548C\u4E0B\u5C5E\u7EC4\u7EC7"),Y=i("\u4EC5\u67E5\u770B\u672C\u4EBA"),G={key:0},J=i("\u81EA\u5B9A\u4E49\u6570\u636E\u6743\u9650"),M={class:"mb-15"},P=i("\u5168\u9009/\u5168\u4E0D\u9009"),Q=i("\u5C55\u5F00/\u6298\u53E0"),X={style:{"max-height":"280px","overflow-y":"auto"}},se={setup(s,{expose:n}){const e=S({roleId:"",loading:!1,visible:!1,form:{sysDataAuthority:{},sysDataAuthorityCustomList:[]},selectAll:!1,expandedAll:!1,tree:{data:[],expandedKeys:[],selectedKeys:[],checkedKeys:[],allKeys:[],allExpandedKeys:[],loadingTree:!1}}),u={openWindow({visible:l,key:t}){e.visible=l,e.roleId=t,this.findForm()},findForm(){e.saveLoading=!0,$.getDataAuthorityByRoleId(e.roleId).then(l=>{e.saveLoading=!1,l.code==1&&(e.form=l.data,e.form.sysDataAuthority.roleId=e.roleId,this.sysOrganizationTree())})},sysOrganizationTree(){e.tree.loadingTree=!0,e.tree.checkedKeys=[],U.sysOrganizationTree().then(l=>{e.tree.loadingTree=!1;let t=l.data;e.tree.data=t.rows,e.tree.expandedKeys=t.expandedRowKeys,e.tree.allKeys=t.allKeys,e.tree.allExpandedKeys=t.expandedRowKeys;var c=e.form.sysDataAuthorityCustomList;for(let y=0;y<c.length;y++){const f=c[y];e.tree.checkedKeys.push(f.sysOrganizationId)}e.selectAll=e.tree.checkedKeys.length==e.tree.allKeys.length,e.expandedAll=e.tree.expandedKeys.length==e.tree.allExpandedKeys.length})},saveForm(){if(e.form.sysDataAuthority.permissionType===1){var l=e.tree.checkedKeys;e.form.sysDataAuthorityCustomList=[];for(let t=0;t<l.length;t++){const c=l[t];e.form.sysDataAuthorityCustomList.push({sysOrganizationId:c})}}else e.form.sysDataAuthorityCustomList=[];$.saveForm(e.form).then(t=>{if(t.code!=1)return g.message("\u4FDD\u5B58\u5931\u8D25!","\u9519\u8BEF");g.message("\u4FDD\u5B58\u6210\u529F!","\u6210\u529F")})},onSelectAll(){e.selectAll?e.tree.checkedKeys=e.tree.allKeys:e.tree.checkedKeys=[]},onExpandedAll(){e.expandedAll?e.tree.expandedKeys=e.tree.allExpandedKeys:e.tree.expandedKeys=[]}};return k(()=>e.tree.checkedKeys,l=>{console.log("checkedKeys",l),e.selectAll=l.length==e.tree.allKeys.length}),k(()=>e.tree.expandedKeys,l=>{e.expandedAll=l.length==e.tree.allExpandedKeys.length}),n(K({},u)),(l,t)=>{const c=p("a-button"),y=p("a-radio"),f=p("a-radio-group"),C=p("a-divider"),x=p("a-checkbox"),L=p("a-tree"),w=p("a-spin"),T=p("a-modal");return b(),z(T,{visible:a(e).visible,"onUpdate:visible":t[9]||(t[9]=o=>a(e).visible=o),title:"\u6570\u636E\u6743\u9650\u8BBE\u7F6E",centered:"",onOk:t[10]||(t[10]=o=>a(e).visible=!1),width:400,bodyStyle:{overflowY:"auto",height:"calc(100vh - 300px)"}},{footer:d(()=>[r(c,{type:"primary",onClick:t[0]||(t[0]=o=>u.saveForm()),loading:a(e).saveLoading},{default:d(()=>[N]),_:1},8,["loading"]),r(c,{type:"danger",ghost:"",onClick:t[1]||(t[1]=o=>a(e).visible=!1),class:"ml-15"},{default:d(()=>[R]),_:1})]),default:d(()=>[r(w,{spinning:a(e).loading},{default:d(()=>[r(f,{value:a(e).form.sysDataAuthority.permissionType,"onUpdate:value":t[2]||(t[2]=o=>a(e).form.sysDataAuthority.permissionType=o)},{default:d(()=>[r(y,{style:{display:"flex",height:"30px",lineHeight:"30px"},value:1},{default:d(()=>[V]),_:1}),r(y,{style:{display:"flex",height:"30px",lineHeight:"30px"},value:2},{default:d(()=>[j]),_:1}),r(y,{style:{display:"flex",height:"30px",lineHeight:"30px"},value:3},{default:d(()=>[q]),_:1}),r(y,{style:{display:"flex",height:"30px",lineHeight:"30px"},value:4},{default:d(()=>[W]),_:1}),r(y,{style:{display:"flex",height:"30px",lineHeight:"30px"},value:5},{default:d(()=>[Y]),_:1})]),_:1},8,["value"]),a(e).form.sysDataAuthority.permissionType===1?(b(),H("div",G,[r(C,null,{default:d(()=>[J]),_:1}),D("div",M,[r(x,{checked:a(e).selectAll,"onUpdate:checked":t[3]||(t[3]=o=>a(e).selectAll=o),onChange:t[4]||(t[4]=o=>u.onSelectAll())},{default:d(()=>[P]),_:1},8,["checked"]),r(x,{checked:a(e).expandedAll,"onUpdate:checked":t[5]||(t[5]=o=>a(e).expandedAll=o),onChange:t[6]||(t[6]=o=>u.onExpandedAll())},{default:d(()=>[Q]),_:1},8,["checked"])]),D("div",X,[r(L,{expandedKeys:a(e).tree.expandedKeys,"onUpdate:expandedKeys":t[7]||(t[7]=o=>a(e).tree.expandedKeys=o),checkedKeys:a(e).tree.checkedKeys,"onUpdate:checkedKeys":t[8]||(t[8]=o=>a(e).tree.checkedKeys=o),checkable:"","tree-data":a(e).tree.data},null,8,["expandedKeys","checkedKeys","tree-data"])])])):O("",!0)]),_:1},8,["spinning"])]),_:1},8,["visible","bodyStyle"])}}};export{se as default};