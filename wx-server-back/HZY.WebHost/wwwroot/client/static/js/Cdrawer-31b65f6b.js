import{_ as g,a as h,r as w,H as c,c as d,j as a,q as C,w as k,l as _,d as t,f as y,e as B,F as L,C as V,I as H,n as p}from"./index-4ae57506.js";const N={key:0,class:"example"},T={key:1,class:"content"},j=p("      "),F=["innerHTML"],I=p(`\r
    `),M={name:"Cdrawer"},q=Object.assign(M,{props:{visible:Boolean},emits:["update:visible"],setup(i,{expose:u,emit:v}){const o=i,r=h(o.visible),e=w({spinning:!0,data:[]});c(()=>o.visible,s=>{s||(e.data=[]),r.value=s}),c(()=>e.data,s=>{e.spinning=!1});const m=()=>{v("update:visible",r.value)};return u({state:e}),(s,l)=>{const b=d("a-spin"),f=d("a-drawer");return a(),C(f,{visible:i.visible,"onUpdate:visible":l[0]||(l[0]=n=>H(visible)?visible.value=n:null),class:"custom-class",title:"\u65E5\u5FD7",width:"700",placement:"right",onAfterVisibleChange:m},{default:k(()=>[_(e).spinning?(a(),t("div",N,[y(b,{tip:"Loading..."})])):(a(),t("div",T,[B("pre",null,[j,(a(!0),t(L,null,V(_(e).data,(n,x)=>(a(),t("p",{key:x,innerHTML:n},null,8,F))),128)),I])]))]),_:1},8,["visible"])}}});var E=g(q,[["__scopeId","data-v-e2c1f11a"]]);export{E as default};
