import{p as s,t as a,s as t}from"./index-4ae57506.js";const r="admin/QuartzTasks";var u={findList(e){return s(`${r}/findList/${e||""}`,null,!1)},deleteList(e){return console.log(e),e&&e.length===0?a.message("\u8BF7\u9009\u62E9\u8981\u5220\u9664\u7684\u6570\u636E!","\u8B66\u544A"):s(`${r}/deleteList`,e,!1)},findForm(e){return t(`${r}/findForm${e?"/"+e:""}`)},saveForm(e){return s(`${r}/saveForm`,e)},run(e){return s(`${r}/run`,e,!1)},close(e){return s(`${r}/close`,e,!1)},getJobLoggers(e,o,n=15){return t(`${r}/getJobLoggers/${e}/${o}/${n}`)}};export{u as s};
