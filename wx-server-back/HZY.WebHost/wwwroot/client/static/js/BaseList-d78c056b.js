import{r as f,a as v,T as w,c as d,U as N,j as t,d as c,L as B,q as C,w as l,n as m,k as s,l as a,e as i,f as L,v as D,B as P}from"./index-e5dbf13d.js";const S=m("\u6253\u5370"),V={id:"print"},I={key:0},J={name:"BaseListCom"},T=Object.assign(J,{setup(U){const o=f({columns:[{title:"Name",dataIndex:"name"},{title:"Age",dataIndex:"age"},{title:"Address",dataIndex:"address"}],data:[{key:"1",name:"John Brown",age:32,address:"New York No. 1 Lake Park"},{key:"2",name:"Jim Green",age:42,address:"London No. 1 Lake Park"},{key:"3",name:"Joe Black",age:32,address:"Sidney No. 1 Lake Park"},{key:"4",name:"Disabled User",age:99,address:"Sidney No. 1 Lake Park"}]}),_={onChange:(e,r)=>{console.log(`selectedRowKeys: ${e}`,"selectedRows: ",r)},getCheckboxProps:e=>({disabled:e.name==="Disabled User",name:e.name})},n=v(null),{x:k,y:u,style:p}=w(n,{initialValue:{x:500,y:200}});return(e,r)=>{const y=d("a-button"),g=d("a-table"),x=N("print");return t(),c("div",null,[B((t(),C(y,{type:"primary",class:"mb-15"},{default:l(()=>[S]),_:1})),[[x,"#print"]]),m(" x:"+s(a(k))+"y:"+s(a(u))+" ",1),i("div",V,[L(g,{"row-selection":_,columns:a(o).columns,"data-source":a(o).data},{bodyCell:l(({column:b,text:h})=>[b.dataIndex==="name"?(t(),c("a",I,s(h),1)):D("",!0)]),_:1},8,["columns","data-source"])]),i("div",{ref_key:"el",ref:n,style:P([a(p),{position:"fixed","background-color":"red",width:"100px",height:"100px"}])},"\u5FEB\u62D6\u52A8\u6211...",4)])}}});export{T as default};
