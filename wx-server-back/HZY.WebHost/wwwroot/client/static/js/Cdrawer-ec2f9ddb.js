import{_ as g,a as h,r as w,H as d,c,j as a,q as C,w as k,l as _,d as t,f as y,e as B,F as L,C as V,I as H,n as p}from"./index-703a0050.js";const N={key:0,class:"example"},T={key:1,class:"content"},j=p("      "),F=["innerHTML"],I=p(`\r
    `),M={name:"Cdrawer"},q=Object.assign(M,{props:{visible:Boolean},emits:["update:visible"],setup(o,{expose:u,emit:v}){const r=o,n=h(r.visible),e=w({spinning:!0,data:[]});d(()=>r.visible,s=>{s||(e.data=[]),n.value=s}),d(()=>e.data,s=>{e.spinning=!1});const b=()=>{console.log(n.value),v("update:visible",n.value)};return u({state:e}),(s,l)=>{const m=c("a-spin"),x=c("a-drawer");return a(),C(x,{visible:o.visible,"onUpdate:visible":l[0]||(l[0]=i=>H(visible)?visible.value=i:null),class:"custom-class",title:"\u65E5\u5FD7",width:"700",placement:"right",onAfterVisibleChange:b},{default:k(()=>[_(e).spinning?(a(),t("div",N,[y(m,{tip:"Loading..."})])):(a(),t("div",T,[B("pre",null,[j,(a(!0),t(L,null,V(_(e).data,(i,f)=>(a(),t("p",{key:f,innerHTML:i},null,8,F))),128)),I])]))]),_:1},8,["visible"])}}});var E=g(q,[["__scopeId","data-v-1db74a3b"]]);export{E as default};