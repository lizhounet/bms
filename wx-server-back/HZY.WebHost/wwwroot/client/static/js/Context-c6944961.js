import{s as d}from"./monitor_ef_core_service-58c3de05.js";import{_ as f,a as r,R as _,j as i,d as h,e as o,k as e,q as u,s as p}from"./index-75374896.js";const c=l=>(u("data-v-10f7d68c"),l=l(),p(),l),v={class:"context"},x={class:"panel-color-1 text-center"},y=c(()=>o("h2",{style:{color:"#fff"}},"\u6570\u636E\u8FDE\u63A5\u6253\u5F00\u6570",-1)),C={style:{color:"#fff"}},g={class:"panel-color-2 text-center"},b=c(()=>o("h2",{style:{color:"#fff"}},"\u6570\u636E\u8FDE\u63A5\u65AD\u5F00\u6570",-1)),m={style:{color:"#fff"}},k={class:"panel-color-3 text-center"},F=c(()=>o("h2",{style:{color:"#fff"}},"\u8FDE\u63A5\u5931\u8D25\u6570\u91CF",-1)),I={style:{color:"#fff"}},B={class:"panel-color-4 text-center"},E=c(()=>o("h2",{style:{color:"#fff"}},"\u521B\u5EFA\u547D\u4EE4\u6570",-1)),M={style:{color:"#fff"}},S={class:"panel-color-5 text-center"},D=c(()=>o("h2",{style:{color:"#fff"}},"\u6267\u884C\u547D\u4EE4\u6570",-1)),T={style:{color:"#fff"}},j={class:"panel-color-6 text-center"},q=c(()=>o("h2",{style:{color:"#fff"}},"\u547D\u4EE4\u6267\u884C\u5931\u8D25\u6570\u91CF",-1)),w={style:{color:"#fff"}},N={class:"panel-color-7 text-center"},R=c(()=>o("h2",{style:{color:"#fff"}},"\u521B\u5EFA\u4E8B\u52A1\u6570",-1)),U={style:{color:"#fff"}},V={class:"panel-color-8 text-center"},z=c(()=>o("h2",{style:{color:"#fff"}},"\u63D0\u4EA4\u4E8B\u52A1\u6570",-1)),A={style:{color:"#fff"}},G={class:"panel-color-9 text-center"},H=c(()=>o("h2",{style:{color:"#fff"}},"\u56DE\u6EDA\u4E8B\u52A1\u6570",-1)),J={style:{color:"#fff"}},K={class:"panel-color-10 text-center"},L=c(()=>o("h2",{style:{color:"#fff"}},"\u4E8B\u52A1\u5931\u8D25\u6570",-1)),O={style:{color:"#fff"}},P={setup(l){const t=r({}),s={getEFCoreMonitorContext(){d.getEFCoreMonitorContext().then(a=>{t.value=a.data})}};s.getEFCoreMonitorContext();let n=r(null);return n.value=setInterval(()=>{s.getEFCoreMonitorContext()},10*1e3),_(()=>{clearInterval(n.value)}),(a,Q)=>(i(),h("div",v,[o("ul",null,[o("li",x,[y,o("h2",C,e(t.value.openDbConnectionCount),1)]),o("li",g,[b,o("h2",m,e(t.value.closeDbConnectionCount),1)]),o("li",k,[F,o("h2",I,e(t.value.connectionFailedCount),1)]),o("li",B,[E,o("h2",M,e(t.value.createCommandCount),1)]),o("li",S,[D,o("h2",T,e(t.value.executeCommandCount),1)])]),o("ul",null,[o("li",j,[q,o("h2",w,e(t.value.commandFailedCount),1)]),o("li",N,[R,o("h2",U,e(t.value.createTransactionCount),1)]),o("li",V,[z,o("h2",A,e(t.value.submitTransactionCount),1)]),o("li",G,[H,o("h2",J,e(t.value.rollBackCount),1)]),o("li",K,[L,o("h2",O,e(t.value.transactionFailedCount),1)])])]))}};var Y=f(P,[["__scopeId","data-v-10f7d68c"]]);export{Y as default};
