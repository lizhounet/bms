import{c as m,G as s,a,m as f,N as l,M as g,b as h,S as d}from"./track-c7322977.js";import{W as C,X as y,o as v,j as b,d as x}from"./index-75374896.js";import k from"./Index3Count-9f540cd1.js";const i=m({type:"vue componnet"});s.registerVueComponent=i.register;s.unregisterVueComponent=i.unregister;s.Hook.prototype.getVueComponent=function(o){const n=this.options.getVueComponent;if(typeof n=="function"){const t=a(n,this.graph,o);if(t!=null)return t}let e=o.getComponent();if(typeof e=="string"){const t=i.get(e);if(t==null)return i.onNotFound(e);e=t}return e};class p extends l{get component(){return this.getComponent()}set component(n){this.setComponent(n)}getComponent(){return this.store.get("component")}setComponent(n,e={}){return n==null?this.removeComponent(e):this.store.set("component",n,e),this}removeComponent(n={}){return this.store.remove("component",n),this}}(function(o){function n(e,t="rect"){const r=[{tagName:t,selector:"body"}];return e?r.push(g.getForeignObjectMarkup()):r.push({tagName:"g",selector:"content"}),r.push({tagName:"text",selector:"label"}),r}o.config({view:"vue-shape-view",markup:n(!0),attrs:{body:{fill:"none",stroke:"none",refWidth:"100%",refHeight:"100%"},fo:{refWidth:"100%",refHeight:"100%"},label:{fontSize:14,fill:"#333",refX:"50%",refY:"50%",textAnchor:"middle",textVerticalAnchor:"middle"}},propHooks(e){if(e.markup==null){const t=e.primer,r=e.useForeignObject;if((t!=null||r!=null)&&(e.markup=n(r!==!1,t),t)){e.attrs==null&&(e.attrs={});let c={};t==="circle"?c={refCx:"50%",refCy:"50%",refR:"50%"}:t==="ellipse"&&(c={refCx:"50%",refCy:"50%",refRx:"50%",refRy:"50%"}),t!=="rect"&&(e.attrs=f({},e.attrs,{body:Object.assign({refWidth:null,refHeight:null},c)}))}}return e}}),l.registry.register("vue-shape",o,!0)})(p||(p={}));globalThis&&globalThis.__rest;class u extends h{init(){super.init()}getComponentContainer(){return this.selectors.foContent}confirmUpdate(n){const e=super.confirmUpdate(n);return this.handleAction(e,u.action,()=>{d.scheduleTask(()=>{this.renderVueComponent()})})}renderVueComponent(){this.unmountVueComponent();const n=this.getComponentContainer(),e=this.cell,t=this.graph;if(n){const r=this.graph.hook.getVueComponent(e);this.vm=C({render(){return y(r)},provide(){return{getGraph:()=>t,getNode:()=>e}}}),this.vm.mount(n)}}unmountVueComponent(){const n=this.getComponentContainer();return this.vm&&(this.vm.unmount(),this.vm=null),n.innerHTML="",n}unmount(){return this.unmountVueComponent(),super.unmount(),this}}(function(o){o.action="vue",o.config({bootstrap:[o.action],actions:{component:o.action}}),h.registry.register("vue-shape-view",o,!0)})(u||(u={}));const O={id:"x6-container3",style:{"min-height":"500px"}},w={setup(o){return s.registerNode("hzy-count",{inherit:"vue-shape",x:200,y:150,width:150,height:100,component:{template:"<Count />",components:{Count:k}}}),v(()=>{new s({container:document.getElementById("x6-container3"),height:400,grid:!0}).addNode({id:"1",shape:"hzy-count",x:400,y:150,width:150,height:100,data:{num:0}})}),(n,e)=>(b(),x("div",O))}};export{w as default};
