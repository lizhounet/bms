var h=Object.defineProperty;var c=Object.getOwnPropertySymbols;var d=Object.prototype.hasOwnProperty,u=Object.prototype.propertyIsEnumerable;var n=(e,t,a)=>t in e?h(e,t,{enumerable:!0,configurable:!0,writable:!0,value:a}):e[t]=a,i=(e,t)=>{for(var a in t||(t={}))d.call(t,a)&&n(e,a,t[a]);if(c)for(var a of c(t))u.call(t,a)&&n(e,a,t[a]);return e};import{C as p}from"./index-535268b1.js";import{_ as l,x as m,r as f,K as s,o as b,H as j,y as O,j as _,d as y}from"./index-e5dbf13d.js";const g=m({name:"LineChartMultiple",props:{id:{type:String,default(){return new Date().getTime()+"_"+Math.floor(Math.random()*1e3)}},data:Array,height:{type:Number,default(){return 500}}},setup(e){const t=f({id:s(()=>e.id),chartObject:null,data:s(()=>e.data)}),a=()=>{t.chartObject=new p({container:t.id,autoFit:!0,height:e.height}),t.chartObject.scale({x:{min:0},y:{type:"pow",nice:!0},group:{}}),t.chartObject.axis("y",{label:{formatter:r=>parseFloat(r).toFixed(2)}}),t.chartObject.tooltip({showCrosshairs:!0,shared:!0}),t.chartObject.line().position("x*y").color("group").shape("smooth"),t.chartObject.point().position("x*y").color("group").shape("circle")},o=r=>{!t.chartObject||(t.chartObject.annotation().clear(!0),t.chartObject.data(r),t.chartObject.render())};return b(()=>{a(),o(t.data)}),j(t.data,r=>{o(r)}),i({},O(t))}}),x=["id"];function C(e,t,a,o,r,w){return _(),y("div",{id:e.id},null,8,x)}var F=l(g,[["render",C]]);export{F as default};
