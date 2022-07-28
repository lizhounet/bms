var j=Object.defineProperty;var U=Object.getOwnPropertySymbols;var D=Object.prototype.hasOwnProperty,E=Object.prototype.propertyIsEnumerable;var F=(f,r,d)=>r in f?j(f,r,{enumerable:!0,configurable:!0,writable:!0,value:d}):f[r]=d,T=(f,r)=>{for(var d in r||(r={}))D.call(r,d)&&F(f,d,r[d]);if(U)for(var d of U(r))E.call(r,d)&&F(f,d,r[d]);return f};import{_ as H,r as A,a as G,c as s,j as g,q as w,w as l,f as a,l as o,d as N,C as S,F as C,n as v,aV as h,t as O,aS as J,k as R}from"./index-997773e6.js";import{o as K}from"./organizationService-32f8eaf2.js";const M=v("\u63D0\u4EA4"),Q=v("\u5173\u95ED"),W=v("\u9501\u5B9A"),X=v("\u4E0D\u9501\u5B9A"),Y=v("\u5DF2\u6FC0\u6D3B"),Z=v("\u672A\u6FC0\u6D3B"),ee=v("\u505C\u7528"),ae={emits:["onSuccess"],setup(f,{expose:r,emit:d}){const e=A({vm:{id:"",form:{},roleIds:[],allRoleList:[],allPostList:[]},visible:!1,saveLoading:!1,organizationTree:[]}),b=G(null),q={name:[{required:!0,message:"\u8BF7\u8F93\u5165\u771F\u5B9E\u59D3\u540D",trigger:"blur"}],loginName:[{required:!0,message:"\u8BF7\u8F93\u5165\u8D26\u6237\u540D\u79F0",trigger:"blur"}]},c={findForm(){return e.saveLoading=!0,h.findForm(e.vm.id).then(u=>{e.saveLoading=!1,u.code==1&&(e.vm=u.data,e.vm.form.password="")})},saveForm(){if(!e.vm.form.organizationId)return O.message("\u8BF7\u9009\u62E9\u7EC4\u7EC7","\u8B66\u544A");b.value.validate().then(()=>{e.saveLoading=!0,h.saveForm(e.vm).then(u=>{u.code==1&&(O.message("\u64CD\u4F5C\u6210\u529F!","\u6210\u529F"),d("onSuccess",u.data),e.visible=!1)}).finally(()=>{e.saveLoading=!1})})},openForm({visible:u,key:t,organizationId:x}){e.visible=u,u&&(e.vm.id=t,J(()=>{b.value.resetFields(),c.sysOrganizationTree()}),c.findForm().then(_=>{t||(e.vm.form.organizationId=x)}))},sysOrganizationTree(){K.sysOrganizationTree().then(u=>{e.organizationTree=u.data.rows})}};return r(T({},c)),(u,t)=>{const x=s("a-button"),_=s("a-input"),i=s("a-form-item"),m=s("a-col"),B=s("a-tree-select"),p=s("a-radio"),L=s("a-radio-group"),I=s("a-checkbox"),k=s("a-row"),z=s("a-checkbox-group"),V=s("a-form"),$=s("a-spin"),P=s("a-modal");return g(),w(P,{visible:o(e).visible,"onUpdate:visible":t[12]||(t[12]=n=>o(e).visible=n),title:o(e).vm.id?"\u7F16\u8F91":"\u65B0\u5EFA",centered:"",onOk:t[13]||(t[13]=n=>o(e).visible=!1),width:800},{footer:l(()=>[a(x,{type:"primary",onClick:t[0]||(t[0]=n=>c.saveForm()),loading:o(e).saveLoading},{default:l(()=>[M]),_:1},8,["loading"]),a(x,{type:"danger",ghost:"",onClick:t[1]||(t[1]=n=>o(e).visible=!1),class:"ml-15"},{default:l(()=>[Q]),_:1})]),default:l(()=>[a($,{spinning:o(e).saveLoading},{default:l(()=>[a(V,{ref_key:"formRef",ref:b,layout:"vertical",model:o(e).vm.form,rules:q},{default:l(()=>[a(k,{gutter:[15,15]},{default:l(()=>[a(m,{xs:24,sm:12,md:12,lg:12,xl:12},{default:l(()=>[a(i,{label:"\u771F\u5B9E\u59D3\u540D",ref:"name",name:"name"},{default:l(()=>[a(_,{value:o(e).vm.form.name,"onUpdate:value":t[2]||(t[2]=n=>o(e).vm.form.name=n),placeholder:"\u8BF7\u8F93\u5165"},null,8,["value"])]),_:1},512)]),_:1}),a(m,{xs:24,sm:12,md:12,lg:12,xl:12},{default:l(()=>[a(i,{label:"\u8D26\u6237\u540D\u79F0",ref:"loginName",name:"loginName"},{default:l(()=>[a(_,{value:o(e).vm.form.loginName,"onUpdate:value":t[3]||(t[3]=n=>o(e).vm.form.loginName=n),placeholder:"\u8BF7\u8F93\u5165"},null,8,["value"])]),_:1},512)]),_:1}),a(m,{xs:24,sm:12,md:12,lg:12,xl:12},{default:l(()=>[a(i,{label:"\u8D26\u6237\u5BC6\u7801"},{default:l(()=>[a(_,{value:o(e).vm.form.password,"onUpdate:value":t[4]||(t[4]=n=>o(e).vm.form.password=n),placeholder:"\u8BF7\u8F93\u5165"},null,8,["value"])]),_:1})]),_:1}),a(m,{xs:24,sm:12,md:12,lg:12,xl:12},{default:l(()=>[a(i,{label:"\u8054\u7CFB\u7535\u8BDD"},{default:l(()=>[a(_,{value:o(e).vm.form.phone,"onUpdate:value":t[5]||(t[5]=n=>o(e).vm.form.phone=n),placeholder:"\u8BF7\u8F93\u5165"},null,8,["value"])]),_:1})]),_:1}),a(m,{xs:24,sm:12,md:12,lg:12,xl:12},{default:l(()=>[a(i,{label:"\u90AE\u7BB1\u5730\u5740"},{default:l(()=>[a(_,{value:o(e).vm.form.email,"onUpdate:value":t[6]||(t[6]=n=>o(e).vm.form.email=n),placeholder:"\u8BF7\u8F93\u5165"},null,8,["value"])]),_:1})]),_:1}),a(m,{xs:24,sm:12,md:12,lg:12,xl:12},{default:l(()=>[a(i,{label:"\u6240\u5C5E\u7EC4\u7EC7"},{default:l(()=>[a(B,{value:o(e).vm.form.organizationId,"onUpdate:value":t[7]||(t[7]=n=>o(e).vm.form.organizationId=n),"dropdown-style":{maxHeight:"400px",overflow:"auto"},placeholder:"\u6240\u5C5E\u7EC4\u7EC7","allow-clear":"","tree-default-expand-all":"","tree-data":o(e).organizationTree,"field-names":{children:"children",label:"title",key:"key",value:"key"}},null,8,["value","tree-data"])]),_:1})]),_:1}),a(m,{xs:24,sm:12,md:12,lg:12,xl:12},{default:l(()=>[a(i,{label:"\u5220\u9664\u9501\u5B9A"},{default:l(()=>[a(L,{value:o(e).vm.form.deleteLock,"onUpdate:value":t[8]||(t[8]=n=>o(e).vm.form.deleteLock=n)},{default:l(()=>[a(p,{value:!0},{default:l(()=>[W]),_:1}),a(p,{value:!1},{default:l(()=>[X]),_:1})]),_:1},8,["value"])]),_:1})]),_:1}),a(m,{xs:24,sm:12,md:12,lg:12,xl:12},{default:l(()=>[a(i,{label:"\u7528\u6237\u72B6\u6001"},{default:l(()=>[a(L,{value:o(e).vm.form.userState,"onUpdate:value":t[9]||(t[9]=n=>o(e).vm.form.userState=n)},{default:l(()=>[a(p,{value:1},{default:l(()=>[Y]),_:1}),a(p,{value:2},{default:l(()=>[Z]),_:1}),a(p,{value:3},{default:l(()=>[ee]),_:1})]),_:1},8,["value"])]),_:1})]),_:1}),a(m,{xs:24,sm:24,md:24,lg:24,xl:24},{default:l(()=>[a(i,{label:"\u6240\u5C5E\u5C97\u4F4D"},{default:l(()=>[a(z,{value:o(e).vm.postIds,"onUpdate:value":t[10]||(t[10]=n=>o(e).vm.postIds=n),class:"w100"},{default:l(()=>[a(k,{gutter:[16,16]},{default:l(()=>[(g(!0),N(C,null,S(o(e).vm.allPostList,(n,y)=>(g(),w(m,{span:6,key:y},{default:l(()=>[a(I,{value:n.id},{default:l(()=>[v(R(n.name),1)]),_:2},1032,["value"])]),_:2},1024))),128))]),_:1})]),_:1},8,["value"])]),_:1})]),_:1}),a(m,{xs:24},{default:l(()=>[a(i,{label:"\u6240\u5C5E\u89D2\u8272"},{default:l(()=>[a(z,{value:o(e).vm.roleIds,"onUpdate:value":t[11]||(t[11]=n=>o(e).vm.roleIds=n),class:"w100"},{default:l(()=>[a(k,{gutter:[16,16]},{default:l(()=>[(g(!0),N(C,null,S(o(e).vm.allRoleList,(n,y)=>(g(),w(m,{span:6,key:y},{default:l(()=>[a(I,{value:n.id},{default:l(()=>[v(R(n.name),1)]),_:2},1032,["value"])]),_:2},1024))),128))]),_:1})]),_:1},8,["value"])]),_:1})]),_:1})]),_:1})]),_:1},8,["model"])]),_:1},8,["spinning"])]),_:1},8,["visible","title"])}}};var ne=H(ae,[["__scopeId","data-v-c34ef16a"]]);export{ne as default};
