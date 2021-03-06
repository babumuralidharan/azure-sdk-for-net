// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.DataFactories
{
    /// <summary>
    /// Operations for managing pipeline runs.
    /// </summary>
    internal partial class PipelineRunOperations : IServiceOperations<DataPipelineManagementClient>, IPipelineRunOperations
    {
        /// <summary>
        /// Initializes a new instance of the PipelineRunOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal PipelineRunOperations(DataPipelineManagementClient client)
        {
            this._client = client;
        }
        
        private DataPipelineManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.Azure.Management.DataFactories.DataPipelineManagementClient.
        /// </summary>
        public DataPipelineManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// Gets the first page of runs of an activity in the pipeline over a
        /// time range with the link to the next page.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The resource group name of the data factory.
        /// </param>
        /// <param name='dataFactoryName'>
        /// Required. A unique data factory instance name.
        /// </param>
        /// <param name='pipelineName'>
        /// Required. A unique pipeline instance name
        /// </param>
        /// <param name='parameters'>
        /// Required. Parameters required to get the runs of a pipeline.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The GetRuns pipeline operation response.
        /// </returns>
        public async Task<PipelineRunListResponse> ListAsync(string resourceGroupName, string dataFactoryName, string pipelineName, PipelineRunListParameters parameters, CancellationToken cancellationToken)
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (dataFactoryName == null)
            {
                throw new ArgumentNullException("dataFactoryName");
            }
            if (pipelineName == null)
            {
                throw new ArgumentNullException("pipelineName");
            }
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if (parameters.ActivityName == null)
            {
                throw new ArgumentNullException("parameters.ActivityName");
            }
            if (parameters.RunRangeEndTime == null)
            {
                throw new ArgumentNullException("parameters.RunRangeEndTime");
            }
            if (parameters.RunRangeStartTime == null)
            {
                throw new ArgumentNullException("parameters.RunRangeStartTime");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("dataFactoryName", dataFactoryName);
                tracingParameters.Add("pipelineName", pipelineName);
                tracingParameters.Add("parameters", parameters);
                Tracing.Enter(invocationId, this, "ListAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "/subscriptions/" + (this.Client.Credentials.SubscriptionId != null ? this.Client.Credentials.SubscriptionId.Trim() : "") + "/resourcegroups/" + resourceGroupName.Trim() + "/providers/Microsoft.DataFactory/datafactories/" + dataFactoryName.Trim() + "/datapipelines/" + pipelineName.Trim() + "/getruns?";
            url = url + "activityName=" + Uri.EscapeDataString(parameters.ActivityName.ToString());
            url = url + "&start=" + Uri.EscapeDataString(parameters.RunRangeStartTime.ToString());
            url = url + "&end=" + Uri.EscapeDataString(parameters.RunRangeEndTime.ToString());
            url = url + "&status=" + Uri.EscapeDataString(parameters.RunRecordStatus.ToString());
            url = url + "&api-version=2014-12-01-preview";
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-client-request-id", Guid.NewGuid().ToString());
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    PipelineRunListResponse result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new PipelineRunListResponse();
                    JToken responseDoc = null;
                    if (string.IsNullOrEmpty(responseContent) == false)
                    {
                        responseDoc = JToken.Parse(responseContent);
                    }
                    
                    if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                    {
                        JToken valueArray = responseDoc["value"];
                        if (valueArray != null && valueArray.Type != JTokenType.Null)
                        {
                            foreach (JToken valueValue in ((JArray)valueArray))
                            {
                                DataSliceRun dataSliceRunInstance = new DataSliceRun();
                                result.PipelineRuns.Add(dataSliceRunInstance);
                                
                                JToken idValue = valueValue["id"];
                                if (idValue != null && idValue.Type != JTokenType.Null)
                                {
                                    string idInstance = ((string)idValue);
                                    dataSliceRunInstance.Id = idInstance;
                                }
                                
                                JToken tableNameValue = valueValue["tableName"];
                                if (tableNameValue != null && tableNameValue.Type != JTokenType.Null)
                                {
                                    string tableNameInstance = ((string)tableNameValue);
                                    dataSliceRunInstance.TableName = tableNameInstance;
                                }
                                
                                JToken pipelineNameValue = valueValue["pipelineName"];
                                if (pipelineNameValue != null && pipelineNameValue.Type != JTokenType.Null)
                                {
                                    string pipelineNameInstance = ((string)pipelineNameValue);
                                    dataSliceRunInstance.PipelineName = pipelineNameInstance;
                                }
                                
                                JToken activityNameValue = valueValue["activityName"];
                                if (activityNameValue != null && activityNameValue.Type != JTokenType.Null)
                                {
                                    string activityNameInstance = ((string)activityNameValue);
                                    dataSliceRunInstance.ActivityName = activityNameInstance;
                                }
                                
                                JToken computeClusterNameValue = valueValue["computeClusterName"];
                                if (computeClusterNameValue != null && computeClusterNameValue.Type != JTokenType.Null)
                                {
                                    string computeClusterNameInstance = ((string)computeClusterNameValue);
                                    dataSliceRunInstance.ComputeClusterName = computeClusterNameInstance;
                                }
                                
                                JToken statusValue = valueValue["status"];
                                if (statusValue != null && statusValue.Type != JTokenType.Null)
                                {
                                    string statusInstance = ((string)statusValue);
                                    dataSliceRunInstance.Status = statusInstance;
                                }
                                
                                JToken processingStartTimeValue = valueValue["processingStartTime"];
                                if (processingStartTimeValue != null && processingStartTimeValue.Type != JTokenType.Null)
                                {
                                    DateTime processingStartTimeInstance = ((DateTime)processingStartTimeValue);
                                    dataSliceRunInstance.ProcessingStartTime = processingStartTimeInstance;
                                }
                                
                                JToken processingEndTimeValue = valueValue["processingEndTime"];
                                if (processingEndTimeValue != null && processingEndTimeValue.Type != JTokenType.Null)
                                {
                                    DateTime processingEndTimeInstance = ((DateTime)processingEndTimeValue);
                                    dataSliceRunInstance.ProcessingEndTime = processingEndTimeInstance;
                                }
                                
                                JToken batchTimeValue = valueValue["batchTime"];
                                if (batchTimeValue != null && batchTimeValue.Type != JTokenType.Null)
                                {
                                    DateTime batchTimeInstance = ((DateTime)batchTimeValue);
                                    dataSliceRunInstance.BatchTime = batchTimeInstance;
                                }
                                
                                JToken percentCompleteValue = valueValue["percentComplete"];
                                if (percentCompleteValue != null && percentCompleteValue.Type != JTokenType.Null)
                                {
                                    int percentCompleteInstance = ((int)percentCompleteValue);
                                    dataSliceRunInstance.PercentComplete = percentCompleteInstance;
                                }
                                
                                JToken dataSliceStartValue = valueValue["dataSliceStart"];
                                if (dataSliceStartValue != null && dataSliceStartValue.Type != JTokenType.Null)
                                {
                                    DateTime dataSliceStartInstance = ((DateTime)dataSliceStartValue);
                                    dataSliceRunInstance.DataSliceStart = dataSliceStartInstance;
                                }
                                
                                JToken dataSliceEndValue = valueValue["dataSliceEnd"];
                                if (dataSliceEndValue != null && dataSliceEndValue.Type != JTokenType.Null)
                                {
                                    DateTime dataSliceEndInstance = ((DateTime)dataSliceEndValue);
                                    dataSliceRunInstance.DataSliceEnd = dataSliceEndInstance;
                                }
                                
                                JToken timestampValue = valueValue["timestamp"];
                                if (timestampValue != null && timestampValue.Type != JTokenType.Null)
                                {
                                    DateTime timestampInstance = ((DateTime)timestampValue);
                                    dataSliceRunInstance.Timestamp = timestampInstance;
                                }
                                
                                JToken retryAttemptValue = valueValue["retryAttempt"];
                                if (retryAttemptValue != null && retryAttemptValue.Type != JTokenType.Null)
                                {
                                    int retryAttemptInstance = ((int)retryAttemptValue);
                                    dataSliceRunInstance.RetryAttempt = retryAttemptInstance;
                                }
                                
                                JToken hasLogsValue = valueValue["hasLogs"];
                                if (hasLogsValue != null && hasLogsValue.Type != JTokenType.Null)
                                {
                                    bool hasLogsInstance = ((bool)hasLogsValue);
                                    dataSliceRunInstance.HasLogs = hasLogsInstance;
                                }
                                
                                JToken typeValue = valueValue["type"];
                                if (typeValue != null && typeValue.Type != JTokenType.Null)
                                {
                                    string typeInstance = ((string)typeValue);
                                    dataSliceRunInstance.Type = typeInstance;
                                }
                                
                                JToken propertiesSequenceElement = ((JToken)valueValue["properties"]);
                                if (propertiesSequenceElement != null && propertiesSequenceElement.Type != JTokenType.Null)
                                {
                                    foreach (JProperty property in propertiesSequenceElement)
                                    {
                                        string propertiesKey = ((string)property.Name);
                                        string propertiesValue = ((string)property.Value);
                                        dataSliceRunInstance.Properties.Add(propertiesKey, propertiesValue);
                                    }
                                }
                                
                                JToken errorMessageValue = valueValue["errorMessage"];
                                if (errorMessageValue != null && errorMessageValue.Type != JTokenType.Null)
                                {
                                    string errorMessageInstance = ((string)errorMessageValue);
                                    dataSliceRunInstance.ErrorMessage = errorMessageInstance;
                                }
                            }
                        }
                        
                        JToken odatanextLinkValue = responseDoc["@odata.nextLink"];
                        if (odatanextLinkValue != null && odatanextLinkValue.Type != JTokenType.Null)
                        {
                            string odatanextLinkInstance = ((string)odatanextLinkValue);
                            result.NextLink = odatanextLinkInstance;
                        }
                    }
                    
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Gets the next page of pipeline runs with the link to the next page.
        /// </summary>
        /// <param name='nextLink'>
        /// Required. The url to the next pipeline runs page.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The GetRuns pipeline operation response.
        /// </returns>
        public async Task<PipelineRunListResponse> ListNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            // Validate
            if (nextLink == null)
            {
                throw new ArgumentNullException("nextLink");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("nextLink", nextLink);
                Tracing.Enter(invocationId, this, "ListNextAsync", tracingParameters);
            }
            
            // Construct URL
            string url = nextLink.Trim();
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-client-request-id", Guid.NewGuid().ToString());
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    PipelineRunListResponse result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new PipelineRunListResponse();
                    JToken responseDoc = null;
                    if (string.IsNullOrEmpty(responseContent) == false)
                    {
                        responseDoc = JToken.Parse(responseContent);
                    }
                    
                    if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                    {
                        JToken valueArray = responseDoc["value"];
                        if (valueArray != null && valueArray.Type != JTokenType.Null)
                        {
                            foreach (JToken valueValue in ((JArray)valueArray))
                            {
                                DataSliceRun dataSliceRunInstance = new DataSliceRun();
                                result.PipelineRuns.Add(dataSliceRunInstance);
                                
                                JToken idValue = valueValue["id"];
                                if (idValue != null && idValue.Type != JTokenType.Null)
                                {
                                    string idInstance = ((string)idValue);
                                    dataSliceRunInstance.Id = idInstance;
                                }
                                
                                JToken tableNameValue = valueValue["tableName"];
                                if (tableNameValue != null && tableNameValue.Type != JTokenType.Null)
                                {
                                    string tableNameInstance = ((string)tableNameValue);
                                    dataSliceRunInstance.TableName = tableNameInstance;
                                }
                                
                                JToken pipelineNameValue = valueValue["pipelineName"];
                                if (pipelineNameValue != null && pipelineNameValue.Type != JTokenType.Null)
                                {
                                    string pipelineNameInstance = ((string)pipelineNameValue);
                                    dataSliceRunInstance.PipelineName = pipelineNameInstance;
                                }
                                
                                JToken activityNameValue = valueValue["activityName"];
                                if (activityNameValue != null && activityNameValue.Type != JTokenType.Null)
                                {
                                    string activityNameInstance = ((string)activityNameValue);
                                    dataSliceRunInstance.ActivityName = activityNameInstance;
                                }
                                
                                JToken computeClusterNameValue = valueValue["computeClusterName"];
                                if (computeClusterNameValue != null && computeClusterNameValue.Type != JTokenType.Null)
                                {
                                    string computeClusterNameInstance = ((string)computeClusterNameValue);
                                    dataSliceRunInstance.ComputeClusterName = computeClusterNameInstance;
                                }
                                
                                JToken statusValue = valueValue["status"];
                                if (statusValue != null && statusValue.Type != JTokenType.Null)
                                {
                                    string statusInstance = ((string)statusValue);
                                    dataSliceRunInstance.Status = statusInstance;
                                }
                                
                                JToken processingStartTimeValue = valueValue["processingStartTime"];
                                if (processingStartTimeValue != null && processingStartTimeValue.Type != JTokenType.Null)
                                {
                                    DateTime processingStartTimeInstance = ((DateTime)processingStartTimeValue);
                                    dataSliceRunInstance.ProcessingStartTime = processingStartTimeInstance;
                                }
                                
                                JToken processingEndTimeValue = valueValue["processingEndTime"];
                                if (processingEndTimeValue != null && processingEndTimeValue.Type != JTokenType.Null)
                                {
                                    DateTime processingEndTimeInstance = ((DateTime)processingEndTimeValue);
                                    dataSliceRunInstance.ProcessingEndTime = processingEndTimeInstance;
                                }
                                
                                JToken batchTimeValue = valueValue["batchTime"];
                                if (batchTimeValue != null && batchTimeValue.Type != JTokenType.Null)
                                {
                                    DateTime batchTimeInstance = ((DateTime)batchTimeValue);
                                    dataSliceRunInstance.BatchTime = batchTimeInstance;
                                }
                                
                                JToken percentCompleteValue = valueValue["percentComplete"];
                                if (percentCompleteValue != null && percentCompleteValue.Type != JTokenType.Null)
                                {
                                    int percentCompleteInstance = ((int)percentCompleteValue);
                                    dataSliceRunInstance.PercentComplete = percentCompleteInstance;
                                }
                                
                                JToken dataSliceStartValue = valueValue["dataSliceStart"];
                                if (dataSliceStartValue != null && dataSliceStartValue.Type != JTokenType.Null)
                                {
                                    DateTime dataSliceStartInstance = ((DateTime)dataSliceStartValue);
                                    dataSliceRunInstance.DataSliceStart = dataSliceStartInstance;
                                }
                                
                                JToken dataSliceEndValue = valueValue["dataSliceEnd"];
                                if (dataSliceEndValue != null && dataSliceEndValue.Type != JTokenType.Null)
                                {
                                    DateTime dataSliceEndInstance = ((DateTime)dataSliceEndValue);
                                    dataSliceRunInstance.DataSliceEnd = dataSliceEndInstance;
                                }
                                
                                JToken timestampValue = valueValue["timestamp"];
                                if (timestampValue != null && timestampValue.Type != JTokenType.Null)
                                {
                                    DateTime timestampInstance = ((DateTime)timestampValue);
                                    dataSliceRunInstance.Timestamp = timestampInstance;
                                }
                                
                                JToken retryAttemptValue = valueValue["retryAttempt"];
                                if (retryAttemptValue != null && retryAttemptValue.Type != JTokenType.Null)
                                {
                                    int retryAttemptInstance = ((int)retryAttemptValue);
                                    dataSliceRunInstance.RetryAttempt = retryAttemptInstance;
                                }
                                
                                JToken hasLogsValue = valueValue["hasLogs"];
                                if (hasLogsValue != null && hasLogsValue.Type != JTokenType.Null)
                                {
                                    bool hasLogsInstance = ((bool)hasLogsValue);
                                    dataSliceRunInstance.HasLogs = hasLogsInstance;
                                }
                                
                                JToken typeValue = valueValue["type"];
                                if (typeValue != null && typeValue.Type != JTokenType.Null)
                                {
                                    string typeInstance = ((string)typeValue);
                                    dataSliceRunInstance.Type = typeInstance;
                                }
                                
                                JToken propertiesSequenceElement = ((JToken)valueValue["properties"]);
                                if (propertiesSequenceElement != null && propertiesSequenceElement.Type != JTokenType.Null)
                                {
                                    foreach (JProperty property in propertiesSequenceElement)
                                    {
                                        string propertiesKey = ((string)property.Name);
                                        string propertiesValue = ((string)property.Value);
                                        dataSliceRunInstance.Properties.Add(propertiesKey, propertiesValue);
                                    }
                                }
                                
                                JToken errorMessageValue = valueValue["errorMessage"];
                                if (errorMessageValue != null && errorMessageValue.Type != JTokenType.Null)
                                {
                                    string errorMessageInstance = ((string)errorMessageValue);
                                    dataSliceRunInstance.ErrorMessage = errorMessageInstance;
                                }
                            }
                        }
                        
                        JToken odatanextLinkValue = responseDoc["@odata.nextLink"];
                        if (odatanextLinkValue != null && odatanextLinkValue.Type != JTokenType.Null)
                        {
                            string odatanextLinkInstance = ((string)odatanextLinkValue);
                            result.NextLink = odatanextLinkInstance;
                        }
                    }
                    
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}
