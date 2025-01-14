﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ONE.Utilities;
using Newtonsoft.Json;
using ONE.Models.CSharp;

namespace ONE.Enterprise.Authentication
{
    public class AuthenticationApi
    {
        public AuthenticationApi(PlatformEnvironment environment, bool continueOnCapturedContext)
        {
            _environment = environment;
            _continueOnCapturedContext = continueOnCapturedContext;
        }
        private PlatformEnvironment _environment;
        private bool _continueOnCapturedContext;
        public bool AutoRenewToken { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public User User { get; set; }
        private HttpClient _httpJsonClient;
        private HttpClient _httpProtocolBufferClient;
        public event EventHandler<ClientApiLoggerEventArgs> Event = delegate { };
        public Token Token { get; set; }
        public HttpClient HttpJsonClient
        {
            get
            {
                if (AutoRenewToken && Token != null && Token.expires < DateTime.Now && !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
                {
                    if (!LoginResourceOwnerAsync(UserName, Password).Result)
                    {
                        Token = null;
                    }
                        
                }
                if (_httpJsonClient == null)
                {
                    _httpJsonClient = new HttpClient();
                    if (_environment != null)
                        _httpJsonClient.BaseAddress = _environment.BaseUri;
                    _httpJsonClient.Timeout = TimeSpan.FromMinutes(10);
                    _httpJsonClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                }
                return _httpJsonClient;
            }
        }
        public HttpClient GetLocalHttpJsonClient(string endpointURL)
        {
            if (AutoRenewToken && Token != null && Token.expires < DateTime.Now && !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {
                if (!LoginResourceOwnerAsync(UserName, Password).Result)
                {
                    Token = null;
                }

            }
            var httpClient = new HttpClient();
            if (_environment != null)
                httpClient.BaseAddress = new Uri($"{_environment.BaseUri}:{GetLocalHttpPort(endpointURL)}/");
            httpClient.Timeout = TimeSpan.FromMinutes(10);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
        public HttpClient HttpProtocolBufferClient
        {
            get
            {
                if (AutoRenewToken && Token != null && Token.expires < DateTime.Now && !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
                {
                    if (!LoginResourceOwnerAsync(UserName, Password).Result)
                    {
                        Token = null;
                    }

                }
                if (_httpProtocolBufferClient == null)
                {
                    _httpProtocolBufferClient = new HttpClient();
                    if (_environment != null)
                        _httpProtocolBufferClient.BaseAddress = _environment.BaseUri;
                    _httpProtocolBufferClient.Timeout = TimeSpan.FromMinutes(10);
                    _httpProtocolBufferClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/protobuf"));

                }
                return _httpProtocolBufferClient;
            }
        }
        public HttpClient GetLocalHttpProtocolBufferClient(string endpointURL)
        {
            if (AutoRenewToken && Token != null && Token.expires < DateTime.Now && !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {
                if (!LoginResourceOwnerAsync(UserName, Password).Result)
                {
                    Token = null;
                }

            }
            var httpClient = new HttpClient();
            if (_environment != null)
                httpClient.BaseAddress = new Uri($"{_environment.BaseUri}:{GetLocalHttpPort(endpointURL)}/");
            httpClient.Timeout = TimeSpan.FromMinutes(10);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/protobuf"));
            return httpClient;
        }
        public int GetLocalHttpPort(string uri)
        {
            if (string.IsNullOrEmpty(uri))
                return 0;
            uri = uri.ToUpper();
            if (uri.Contains("COMMON/COMPUTATION"))
                return 9006;
            if (uri.Contains("COMMON/NOTIFICATION"))
                return 9004;
            if (uri.Contains("COMMON/TIMEZONE"))
                return 9001;
            if (uri.Contains("COMMON/ACTIVITY"))
                return 8918;
            if (uri.Contains("COMMON/LIBRARY"))
                return 9201;
            if (uri.Contains("ENTERPRISE/TWIN"))
                return 8900;
            if (uri.Contains("ENTERPRISE/CORE"))
                return 9100;
            if (uri.Contains("ENTERPRISE/REPORT"))
                return 9090;
            if (uri.Contains("OPERATIONS/SPREADSHEET"))
                return 9502;
            return 0;
        }
        public string GetLocalUri(string uri)
        {
            if (string.IsNullOrEmpty(uri))
                return "";
            string uppercaseUri = uri.ToUpper();
            if (uppercaseUri.Contains("COMMON/COMPUTATION"))
                return uri.Substring(20);
            if (uppercaseUri.Contains("COMMON/NOTIFICATION"))
                return uri.Substring(23);
            if (uppercaseUri.Contains("COMMON/TIMEZONE"))
                return uri.Substring(20);
            if (uppercaseUri.Contains("COMMON/ACTIVITY"))
                return uri.Substring(20);
            if (uppercaseUri.Contains("COMMON/LIBRARY"))
                return uri.Substring(18);
            if (uppercaseUri.Contains("ENTERPRISE/TWIN"))
                return uri.Substring(19);
            if (uppercaseUri.Contains("ENTERPRISE/CORE"))
                return uri.Substring(19);
            if (uppercaseUri.Contains("ENTERPRISE/REPORT"))
                return uri.Substring(21);
            if (uppercaseUri.Contains("OPERATIONS/SPREADSHEET"))
                return uri.Substring(26);
            return "";
        }
        public void Logout()
        {
            Token = null;
            _httpJsonClient = null;
        }

        public async Task<bool> LoginResourceOwnerAsync(string userName, string password)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Token = new Token();
            var body = new Dictionary<string, string>
            {
                {
                    "client_id",
                    "VSTestClient"
                },
                {
                    "client_secret",
                    "0CCBB786-9412-4088-BC16-78D3A10158B7"
                },
                {
                    "grant_type",
                    "password"
                },
                {
                    "scope",
                    "FFAccessAPI openid"
                },
                {
                    "username",
                    userName
                },
                {
                    "password",
                    password
                }
            };
            string endpointURL = "/connect/token";
            using (var request = new HttpRequestMessage(HttpMethod.Post, endpointURL))
            {
                request.Content = new FormUrlEncodedContent(body);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                using (var respContent = await HttpJsonClient.SendAsync(request).ConfigureAwait(_continueOnCapturedContext))
                {
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    var json = await respContent.Content.ReadAsStringAsync();
                    if (json.Length > 0)
                    {
                        Token = JsonConvert.DeserializeObject<Token>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    }

                    if (Token != null && !string.IsNullOrEmpty(Token.access_token))
                    {
                        HttpJsonClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", Token.access_token);
                        HttpProtocolBufferClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", Token.access_token);
                        UserName = userName;
                        Password = password;
                        Event(null, new ClientApiLoggerEventArgs { EventLevel = EnumEventLevel.Trace, HttpStatusCode = respContent.StatusCode, ElapsedMs = watch.ElapsedMilliseconds, Module = "AuthenticationApi", Message = $"LoginResourceOwnerAsync Success" });
                    }
                    else
                    {
                        Event(null, new ClientApiLoggerEventArgs { EventLevel = EnumEventLevel.Warn, HttpStatusCode = respContent.StatusCode, ElapsedMs = watch.ElapsedMilliseconds, Module = "AuthenticationApi", Message = $"LoginResourceOwnerAsync Failed" });
                    }
                }
            }

            return IsAuthenticated;
        }
        public async Task<string> GetUserInfoAsync()
        {
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                var response = await HttpJsonClient.GetAsync("/connect/userinfo");
                var elapsedMs = watch.ElapsedMilliseconds;

                if (!response.IsSuccessStatusCode)
                {

                    dynamic error = new JObject();
                    error.Client = (JObject)JToken.FromObject(HttpJsonClient);
                    error.Response = (JObject)JToken.FromObject(response);
                    Event(null, new ClientApiLoggerEventArgs { EventLevel = EnumEventLevel.Warn, HttpStatusCode = response.StatusCode, ElapsedMs = elapsedMs, Module = "AuthenticationApi", Message = $"GetUserInfoAync Failed" });

                    return null;
                }
                Event(null, new ClientApiLoggerEventArgs { EventLevel = EnumEventLevel.Trace, HttpStatusCode = response.StatusCode, ElapsedMs = elapsedMs, Module = "AuthenticationApi", Message = $"GetUserInfoAync Success" });

                return await response.Content.ReadAsStringAsync();

            }
            catch (Exception e)
            {
                Event(e, new ClientApiLoggerEventArgs { EventLevel = EnumEventLevel.Error, Module = "AuthenticationAPI" });
                throw;
            }
        }

        public async Task<string> GetTokenAsync(string userName, string password)
        {
            var body = new Dictionary<string, string>
            {
                {
                    "client_id",
                    "VSTestClient"
                },
                {
                    "client_secret",
                    "0CCBB786-9412-4088-BC16-78D3A10158B7"
                },
                {
                    "grant_type",
                    "password"
                },
                {
                    "scope",
                    "FFAccessAPI openid"
                },
                {
                    "username",
                    userName
                },
                {
                    "password",
                    password
                }
            };
            string endpointURL = "/connect/token";
            using (var request = new HttpRequestMessage(HttpMethod.Post, endpointURL))
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                const string tokenKey = "access_token";

                request.Content = new FormUrlEncodedContent(body);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                using (var response = await HttpJsonClient.SendAsync(request).ConfigureAwait(_continueOnCapturedContext))
                {
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    var json = await response.Content.ReadAsStringAsync();
                    if (json.Length > 0)
                    {
                        var jObj = JObject.Parse(json);
                        if (jObj.ContainsKey(tokenKey))
                        {
                            Event(null, new ClientApiLoggerEventArgs { EventLevel = EnumEventLevel.Trace, HttpStatusCode = response.StatusCode, ElapsedMs = elapsedMs, Module = "AuthenticationApi", Message = $"GetTokenAsync Success: {endpointURL}" });
                            return (string)jObj[tokenKey];
                        }
                    }
                    Event(null, new ClientApiLoggerEventArgs { EventLevel = EnumEventLevel.Warn, HttpStatusCode = response.StatusCode, ElapsedMs = elapsedMs, Module = "AuthenticationApi", Message = $"GetTokenAsync Failed: {endpointURL}" });

                    return string.Empty;
                }
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return Token != null && !string.IsNullOrEmpty(Token.access_token) && Token.expires >= DateTime.Now;
            }
        }
    }
}
