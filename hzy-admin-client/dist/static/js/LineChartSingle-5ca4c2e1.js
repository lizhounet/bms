var d=Object.defineProperty;var c=Object.getOwnPropertySymbols;var h=Object.prototype.hasOwnProperty,u=Object.prototype.propertyIsEnumerable;var o=(e,t,a)=>t in e?d(e,t,{enumerable:!0,configurable:!0,writable:!0,value:a}):e[t]=a,i=(e,t)=>{for(var a in t||(t={}))h.call(t,a)&&o(e,a,t[a]);if(c)for(var a of c(t))u.call(t,a)&&o(e,a,t[a]);return e};import{C as l}from"./index-740a892a.js";import{_ as p,y as m,r as f,K as s,o as b,I as j,z as _,j as O,d as g}from"./index-4af06715.js";import"./index-68ae8ebb.js";const v=m({name:"LineChartSingle",props:{id:{type:String,default(){return new Date().getTime()+"_"+Math.floor(Math.random()*1e3)}},data:Array,height:{type:Number,default(){return 500}}},setup(e){const t=f({id:s(()=>e.id),chartObject:null,data:s(()=>e.data)}),a=()=>{t.chartObject=new l({container:t.id,autoFit:!0,height:e.height}),t.chartObject.scale({year:{range:[0,1]},value:{min:0,nice:!0}}),t.chartObject.tooltip({showCrosshairs:!0,shared:!0}),t.chartObject.line().position("year*value").label("value"),t.chartObject.point().position("year*value")},n=r=>{!t.chartObject||(t.chartObject.annotation().clear(!0),t.chartObject.data(r),t.chartObject.render())};return b(()=>{a(),n(t.data)}),j(t.data,r=>{n(r)}),i({},_(t))}}),y=["id"];function C(e,t,a,n,r,w){return O(),g("div",{id:e.id},null,8,y)}var x=p(v,[["render",C]]);export{x as default};
