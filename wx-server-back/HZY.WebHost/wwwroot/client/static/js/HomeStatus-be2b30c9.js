import{h as p}from"./config-756651c9.js";import{s as a,r as u,o as g,v as h,c as n,j as w,q as v,w as s,f as i,n as _,k as d,l as o,e as r}from"./index-e52864b2.js";var I={getWxUserInfo(){return a("/admin/WxBotConfig/WxUserInfo")},checkLogin(c){return a(`/api/feixunbot/check-login/${c}`)},getLoginQrCode(){return a("/api/feixunbot/login-qrcode")}};const U=_(" \u5FAE\u79D8\u4E66\u72B6\u6001 "),y={class:"content"},b={class:"content-info"},S={class:"name"},k={name:"HomeStatus"},B=Object.assign(k,{setup(c){const e=u({wxUserInfo:{avatarUrl:"https://i.52112.com/icon/jpg/256/20210901/130307/5566843.jpg",wxId:"",wxCode:"\u672A\u767B\u5F55",wxName:"\u672A\u767B\u5F55"}});g(()=>{f.init()});const f={init:async()=>{let t=await I.getWxUserInfo();t&&t.code==1&&t.data&&(e.wxUserInfo=t.data)}};return h(e.wxUserInfo),(t,C)=>{const l=n("a-tag"),m=n("a-image"),x=n("a-card");return w(),v(x,{class:"home-status",bordered:!1,hoverable:"",headStyle:o(p)},{title:s(()=>[U,i(l,{color:o(e).wxUserInfo.wxId?"#87d068":"#6a615d"},{default:s(()=>[_(d(o(e).wxUserInfo.wxId?"\u5728\u7EBF":"\u79BB\u7EBF"),1)]),_:1},8,["color"])]),default:s(()=>[r("div",y,[i(m,{width:150,preview:!1,src:o(e).wxUserInfo.avatarUrl},null,8,["src"]),r("div",b,[r("div",S,d(o(e).wxUserInfo.wxName),1)])])]),_:1},8,["headStyle"])}}});export{B as default};
