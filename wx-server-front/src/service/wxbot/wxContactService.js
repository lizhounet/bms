import { get, post, download } from '@/scripts/request';
import tools from "@/scripts/tools";

const controllerName = "admin/WxContact";

export default {
    /**
     * 查询列表
     * 
     * @param {一页显示多少行} rows 
     * @param {当前页码} page 
     */
    findList(rows, page, search = {}) {
        return post(`${controllerName}/findList/${rows}/${page}`, search, false);
    },
    /**
    * 查询所有联系人
    * 
    */
    findAll() {
        return post(`${controllerName}/findAll`,  false);
    },
    /**
     * 删除数据
     * 
     * @param {要删除的id 数组} ids 
     */
    deleteList(ids) {
        console.log(ids);
        if (ids && ids.length === 0) {
            return tools.message("请选择要删除的数据!", "警告");
        }
        return post(`${controllerName}/deleteList`, ids, false);
    },
    /**
     * 获取表单数据
     * 
     * @param {*} id 
     */
    findForm(id) {
        return get(`${controllerName}/findForm${(id ? '/' + id : '')}`);
    },
    /**
     * 保存表单
     * 
     * @param {表单数据} form 
     */
    saveForm(form) {
        return post(`${controllerName}/saveForm`, form);
    },
};