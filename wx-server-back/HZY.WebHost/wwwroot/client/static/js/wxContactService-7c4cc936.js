import{p as r,t as a,s}from"./index-4ae57506.js";const e="admin/WxContact";var f={findList(t,n,o={}){return r(`${e}/findList/${t}/${n}`,o,!1)},findAll(){return r(`${e}/findAll`,!1)},deleteList(t){return console.log(t),t&&t.length===0?a.message("\u8BF7\u9009\u62E9\u8981\u5220\u9664\u7684\u6570\u636E!","\u8B66\u544A"):r(`${e}/deleteList`,t,!1)},findForm(t){return s(`${e}/findForm${t?"/"+t:""}`)},saveForm(t){return r(`${e}/saveForm`,t)},updateContact(){return r(`${e}/updateContact`)}};export{f as w};
