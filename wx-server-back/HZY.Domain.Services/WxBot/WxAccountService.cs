﻿using HZY.EFCore.Repositories.Admin.Core;
using HZY.Models.Consts;
using HZY.Models.DTO.WxBot;
using HZY.Models.Entities;
using HzyScanDiService;
using xYohttp_dotnet.Domain.Model.Vo;
using xYohttp_dotnet.Http;

namespace HZY.Domain.Services.WxBot
{
    /// <summary>
    /// 微信账号服务
    /// </summary>
    public class WxAccountService : IScopedSelfDependency
    {
        private readonly IAdminRepository<WxBotConfig> _wxBotConfigRepository;
        public WxAccountService(IAdminRepository<WxBotConfig> wxBotConfigRepository) {
            _wxBotConfigRepository= wxBotConfigRepository;
        }

        /// <summary>
        /// 获取登录二维码
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetLoginQrCodeAsync(string applictionToken)
        {
            WxBotConfig wxBotConfig = await GetWxBotConfigByApplictionTokenAsync(applictionToken);
            XyoHttpApi xyoHttpApi = new(wxBotConfig.VlwHttpUrl, applictionToken);
            //退出已打开的微信
            await xyoHttpApi.ExitWeChatLoginWinAsync();
            //获取登录二维码
            string loginQrCodeBase64 = await xyoHttpApi.StartWeChatAsync();
            //设置缓存
            return "data:image/png;base64," + loginQrCodeBase64;
        }
        /// <summary>
        /// 根据applictionToken获取用户配置的WxBotConfig
        /// </summary>
        /// <param name="applictionToken"></param>
        /// <returns></returns>
        public async Task<WxBotConfig> GetWxBotConfigByApplictionTokenAsync(string applictionToken) {
            //查询缓存
            WxBotConfig wxBotConfig = RedisHelper.Get<WxBotConfig>(string.Format(CacheKeyConsts.WxBotConfigKey, applictionToken));
            if(wxBotConfig!=null) return wxBotConfig;
            wxBotConfig = await _wxBotConfigRepository.FindAsync(w => w.ApplicationToken == applictionToken);
            RedisHelper.Set(string.Format(CacheKeyConsts.WxBotConfigKey, applictionToken), wxBotConfig);
            return wxBotConfig;

        }

        /// <summary>
        /// 根据applictionToken获取当前登录的微信用户信息
        /// </summary>
        /// <param name="applictionToken"></param>
        /// <returns></returns>
        public async Task<WxUserInfoDTO> GetWxUserInfoByApplictionTokenAsync(string applictionToken)
        {
            WxUserInfoDTO wxUserInfoDTO = RedisHelper.Get<WxUserInfoDTO>(string.Format(CacheKeyConsts.OnlineWxUserInfoKey, applictionToken));
            if (wxUserInfoDTO != null) return wxUserInfoDTO;
            WxBotConfig wxBotConfig = await GetWxBotConfigByApplictionTokenAsync(applictionToken);
            XyoHttpApi xyoHttpApi=new(wxBotConfig.VlwHttpUrl, applictionToken);

            //获取登录的机器人列表
            GetRobotListVo robotList = await xyoHttpApi.GetRobotListAsync();
            Robot robot = robotList.Data.FirstOrDefault();
            var userInfo = new WxUserInfoDTO
            {
                WxCode = robot?.WxNum,
                WxId = robot?.WxId,
                WxName = robot?.UserName,
                AvatarUrl = robot?.WxHeadImgurl
            };
            if (robotList.Number > 0)
            {
                //登录成功 把用户信息存入redis
                RedisHelper.Set(String.Format(CacheKeyConsts.OnlineWxUserInfoKey, applictionToken), userInfo);
            }
            else
            {
                RedisHelper.Del(String.Format(CacheKeyConsts.OnlineWxUserInfoKey, applictionToken));
            }
            return wxUserInfoDTO;
        }
    }
}