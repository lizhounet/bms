var C=Object.defineProperty,k=Object.defineProperties;var B=Object.getOwnPropertyDescriptors;var r=Object.getOwnPropertySymbols;var w=Object.prototype.hasOwnProperty,g=Object.prototype.propertyIsEnumerable;var p=(e,n,t)=>n in e?C(e,n,{enumerable:!0,configurable:!0,writable:!0,value:t}):e[n]=t,d=(e,n)=>{for(var t in n||(n={}))w.call(n,t)&&p(e,t,n[t]);if(r)for(var t of r(n))g.call(n,t)&&p(e,t,n[t]);return e},v=(e,n)=>k(e,B(n));import{_ as I,x as S,A as u,r as h,H as c,v as y,c as s,j as A,d as F,f as i,w as b,I as m}from"./index-997773e6.js";const j=S({name:"FindBack",props:{title:String,label:String,onClear:Function,visible:Boolean},components:{AppIcon:u,AppIcon:u},setup(e,n){const t=h({visible:!1});c(()=>e.visible,o=>{t.visible=o}),c(()=>t.visible,o=>{n.emit("update:visible",o)});const l=()=>{n.emit("onClear"),t.visible=!t.visible};return v(d({},y(t)),{onClear:l})}});function D(e,n,t,l,o,E){const _=s("a-drawer"),f=s("AppIcon"),$=s("a-input-search");return A(),F("div",null,[i(_,{title:e.$props.title,placement:"right",visible:e.visible,width:1300,onClose:n[0]||(n[0]=a=>e.visible=!1)},{default:b(()=>[m(e.$slots,"default",{},void 0,!0)]),_:3},8,["title","visible"]),m(e.$slots,"input",{},()=>[i($,{placeholder:"\u8BF7\u9009\u62E9",value:e.$props.label,"onUpdate:value":n[1]||(n[1]=a=>e.$props.label=a),readonly:"",onClick:n[2]||(n[2]=a=>e.visible=!e.visible),onSearch:e.onClear},{enterButton:b(()=>[i(f,{name:"DeleteOutlined"})]),_:1},8,["value","onSearch"])],!0)])}var O=I(j,[["render",D],["__scopeId","data-v-4cdb25dc"]]);export{O as default};
