import{C as n}from"./index-535268b1.js";import{r as c,o as l,j as i,d as h}from"./index-5045e752.js";const d={id:"container1"},v={setup(p){var a=null;const s=c([{year:"1951 \u5E74",sales:38},{year:"1952 \u5E74",sales:52},{year:"1956 \u5E74",sales:61},{year:"1957 \u5E74",sales:145},{year:"1958 \u5E74",sales:48},{year:"1959 \u5E74",sales:38},{year:"1960 \u5E74",sales:38},{year:"1962 \u5E74",sales:38}]),o=()=>{a=new n({container:"container1",autoFit:!0,height:500}),a.data(s),a.scale("sales",{nice:!0}),a.tooltip({showMarkers:!1}),a.interaction("active-region"),a.interval().position("year*sales"),a.render()},r=()=>{for(var t=[],e=1950;e<1960;e++)t.push({year:e+" \u5E74",sales:Math.floor(Math.random()*200)});a.changeData(t)};return l(()=>{o(),r(),setInterval(()=>r(),2e3)}),(t,e)=>(i(),h("div",d))}};export{v as default};
