import{p as v,t as S,s as $,aU as C,_ as I,r as K,o as U,c as s,j as A,d as B,f as e,w as o,n as u,k as V,l as a,K as b,L as F,aX as R}from"./index-eda3e6f0.js";const m="admin/wxbotconfig";var x={findList(l,p,t={}){return v(`${m}/findList/${l}/${p}`,t,!1)},deleteList(l){return l&&l.length===0?S.message("\u8BF7\u9009\u62E9\u8981\u5220\u9664\u7684\u6570\u636E!","\u8B66\u544A"):v(`${m}/deleteList`,l,!1)},findForm(l){return $(`${m}/findForm${l?"/"+l:""}`)},saveForm(l){return v(`${m}/saveForm`,l)},exportExcel(l){return C(`${m}/exportExcel`,l)}};const E={class:"basic-config"},N=u("\u5929\u884C\u673A\u5668\u4EBA"),P=u("\u817E\u8BAF\u95F2\u804A\u673A\u5668\u4EBA"),X=u("\u7533\u8BF7\u5730\u5740"),D=u("\u7533\u8BF7\u5730\u5740"),j=u("\u4FDD\u5B58"),z={emits:["onSuccess"],setup(l,{emit:p}){const t=K({vm:{id:"",form:{}},visible:!1,saveLoading:!1}),h={findForm(){t.saveLoading=!0,x.findForm(t.vm.id).then(c=>{t.saveLoading=!1,c.code==1&&(t.vm=c.data)})},saveForm(){t.saveLoading=!0,x.saveForm(t.vm.form).then(c=>{t.saveLoading=!1,c.code==1&&(S.message("\u64CD\u4F5C\u6210\u529F!","\u6210\u529F"),p("onSuccess",c.data),t.visible=!1,t.vm.form=c.data)})}};return U(()=>{h.findForm()}),(c,n)=>{const d=s("a-form-item"),y=s("a-switch"),g=s("a-radio"),T=s("a-radio-group"),f=s("a-input"),i=s("a-col"),_=s("a-button"),k=s("a-row"),w=s("v-show"),L=s("a-form");return A(),B("div",E,[e(L,R({layout:"horizontal",model:a(t).vm.form},{labelCol:{span:4},wrapperCol:{span:10}}),{default:o(()=>[e(d,{label:"\u5E73\u53F0\u5E94\u7528Token"},{default:o(()=>[u(V(a(t).vm.form.applicationToken),1)]),_:1}),e(d,{label:"\u7FA4\u804A\u81EA\u52A8\u56DE\u590D\u662F\u5426\u5F00\u542F"},{default:o(()=>[e(y,{checked:a(t).vm.form.groupAutoReplyFlag,"onUpdate:checked":n[0]||(n[0]=r=>a(t).vm.form.groupAutoReplyFlag=r),"checked-children":"\u5F00","un-checked-children":"\u5173",checkedValue:1,unCheckedValue:0},null,8,["checked"])]),_:1}),e(d,{label:"\u79C1\u804A\u81EA\u52A8\u56DE\u590D\u662F\u5426\u5F00\u542F"},{default:o(()=>[e(y,{checked:a(t).vm.form.talkPrivateAutoReplyFlag,"onUpdate:checked":n[1]||(n[1]=r=>a(t).vm.form.talkPrivateAutoReplyFlag=r),"checked-children":"\u5F00","un-checked-children":"\u5173",checkedValue:1,unCheckedValue:0},null,8,["checked"])]),_:1}),e(d,{label:"\u56DE\u590D\u673A\u5668\u4EBA\u7C7B\u578B"},{default:o(()=>[e(T,{value:a(t).vm.form.replyBotType,"onUpdate:value":n[2]||(n[2]=r=>a(t).vm.form.replyBotType=r),"default-value":"1"},{default:o(()=>[e(g,{value:1},{default:o(()=>[N]),_:1}),e(g,{value:2},{default:o(()=>[P]),_:1})]),_:1},8,["value"])]),_:1}),b(e(w,null,{default:o(()=>[e(d,{label:"\u5929\u884C\u673A\u5668\u4EBAkey"},{default:o(()=>[e(k,{gutter:[15,15]},{default:o(()=>[e(i,{span:21},{default:o(()=>[e(f,{value:a(t).vm.form.tianXingApiKey,"onUpdate:value":n[3]||(n[3]=r=>a(t).vm.form.tianXingApiKey=r),placeholder:"\u8BF7\u8F93\u5165 \u5929\u884C\u673A\u5668\u4EBAkey"},null,8,["value"])]),_:1}),e(i,{span:3},{default:o(()=>[e(_,{type:"link",href:"https://www.tianapi.com/signup.html?source=ch4553544"},{default:o(()=>[X]),_:1})]),_:1})]),_:1})]),_:1})]),_:1},512),[[F,a(t).vm.form.replyBotType==1]]),b(e(w,null,{default:o(()=>[e(d,{label:"\u817E\u8BAFTencentSecretId"},{default:o(()=>[e(k,{gutter:[15,15]},{default:o(()=>[e(i,{span:22},{default:o(()=>[e(f,{value:a(t).vm.form.tencentSecretId,"onUpdate:value":n[4]||(n[4]=r=>a(t).vm.form.tencentSecretId=r),placeholder:"\u8BF7\u8F93\u5165 \u817E\u8BAFTencentSecretId"},null,8,["value"])]),_:1}),e(i,{span:2},{default:o(()=>[e(_,{type:"link",href:"https://cloud.tencent.com/document/api/271/39416"},{default:o(()=>[D]),_:1})]),_:1})]),_:1})]),_:1}),e(d,{label:"\u817E\u8BAFTencentSecretKey"},{default:o(()=>[e(f,{value:a(t).vm.form.tencentSecretKey,"onUpdate:value":n[5]||(n[5]=r=>a(t).vm.form.tencentSecretKey=r),placeholder:"\u8BF7\u8F93\u5165 \u817E\u8BAFTencentSecretKey"},null,8,["value"])]),_:1})]),_:1},512),[[F,a(t).vm.form.replyBotType==2]]),e(d,{"wrapper-col":{span:14,offset:4}},{default:o(()=>[e(_,{type:"primary",onClick:n[6]||(n[6]=r=>h.saveForm())},{default:o(()=>[j]),_:1})]),_:1})]),_:1},16,["model"])])}}};var q=I(z,[["__scopeId","data-v-8831f0b2"]]);export{q as default};
