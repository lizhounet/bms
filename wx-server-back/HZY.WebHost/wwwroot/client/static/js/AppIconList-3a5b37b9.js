var A=Object.defineProperty,F=Object.defineProperties;var $=Object.getOwnPropertyDescriptors;var h=Object.getOwnPropertySymbols;var b=Object.prototype.hasOwnProperty,w=Object.prototype.propertyIsEnumerable;var g=(e,o,n)=>o in e?A(e,o,{enumerable:!0,configurable:!0,writable:!0,value:n}):e[o]=n,C=(e,o)=>{for(var n in o||(o={}))b.call(o,n)&&g(e,n,o[n]);if(h)for(var n of h(o))w.call(o,n)&&g(e,n,o[n]);return e},k=(e,o)=>F(e,$(o));import{_ as N,A as z,B,r as x,o as j,z as E,c as L,j as s,d as a,e as l,f as v,k as c,n as p,F as r,m as d,C as _,D as T,E as y,G as V,H as S,I as D}from"./index-5045e752.js";const G=z({name:"AppIconListCom",props:{name:String,height:Number,onChangeName:Function},components:{AppIcon:B},setup(e,o){const n=x({active:1,names:[],antdCount:0,ionicons5Count:0}),u=D(),f=i=>{o.emit("update:name",i),o.emit("onChangeName",i)},m=i=>{n.active=i,i===1&&(n.names=V(u),n.antdCount=n.names.length),i===2&&(n.names=S(u),n.ionicons5Count=n.names.length)};return j(()=>{m(n.active)}),k(C({},E(n)),{onClickIcon:f,onClickTab:m})}}),H={class:"app-icon-list"},M={style:{display:"flex","align-items":"center","justify-content":"center"}},R={class:"app-icon-show"},q={class:"ml-10"},J=d(" Antd "),K=d(" Ionicons5 "),O=["onClick"],P={class:"ml-10"},Q={key:1,class:"icon-list pt-15"},U=["onClick"],W={class:"ml-10"};function X(e,o,n,u,f,m){const i=L("AppIcon");return s(),a("div",H,[l("div",M,[l("div",R,[v(i,{name:e.$props.name,size:40,color:"#fff"},null,8,["name"])]),l("h4",q,c(e.$props.name),1)]),l("ul",null,[l("li",{class:p({active:e.active===1}),onClick:o[0]||(o[0]=t=>e.onClickTab(1))},[J,e.antdCount>0?(s(),a(r,{key:0},[d(" \uFF08\u6570\u91CF:"+c(e.antdCount)+"\u4E2A\uFF09 ",1)],64)):_("",!0)],2),l("li",{class:p({active:e.active===2}),onClick:o[1]||(o[1]=t=>e.onClickTab(2))},[K,e.ionicons5Count>0?(s(),a(r,{key:0},[d(" \uFF08\u6570\u91CF:"+c(e.ionicons5Count)+"\u4E2A\uFF09 ",1)],64)):_("",!0)],2)]),e.$props.height>0?(s(),a("div",{key:0,class:"icon-list pt-15",style:T({height:e.$props.height+"px"})},[(s(!0),a(r,null,y(e.names,t=>(s(),a("div",{class:p(["icon-list-item",{active:e.name==t}]),onClick:I=>e.onClickIcon(t)},[v(i,{name:t,size:20},null,8,["name"]),l("div",P,c(t),1)],10,O))),256))],4)):(s(),a("div",Q,[(s(!0),a(r,null,y(e.names,t=>(s(),a("div",{class:p(["icon-list-item",{active:e.name==t}]),onClick:I=>e.onClickIcon(t)},[v(i,{name:t,size:20},null,8,["name"]),l("div",W,c(t),1)],10,U))),256))]))])}var ee=N(G,[["render",X],["__scopeId","data-v-054f028e"]]);export{ee as default};
