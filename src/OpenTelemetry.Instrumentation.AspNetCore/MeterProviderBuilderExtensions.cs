// <copyright file="MeterProviderBuilderExtensions.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using OpenTelemetry.Instrumentation.AspNetCore;
using OpenTelemetry.Internal;

namespace OpenTelemetry.Metrics
{
    /// <summary>
    /// Extension methods to simplify registering of ASP.NET Core request instrumentation.
    /// </summary>
    public static class MeterProviderBuilderExtensions
    {
        /// <summary>
        /// Enables the incoming requests automatic data collection for ASP.NET Core.
        /// </summary>
        /// <param name="builder"><see cref="MeterProviderBuilder"/> being configured.</param>
        /// <returns>The instance of <see cref="MeterProviderBuilder"/> to chain the calls.</returns>
        public static MeterProviderBuilder AddAspNetCoreInstrumentation(
            this MeterProviderBuilder builder)
        {
            Guard.Null(builder, nameof(builder));

            // TODO: Implement an IDeferredMeterProviderBuilder

            // TODO: Handle AspNetCoreInstrumentationOptions
            //   Filter - makes sense for metric instrumentation
            //   Enrich - do we want a similar kind of functionality for metrics?
            //   RecordException - probably doesn't make sense for metric instrumentation
            //   EnableGrpcAspNetCoreSupport - this instrumentation will also need to also handle gRPC requests

            var instrumentation = new AspNetCoreMetrics();
            builder.AddMeter(AspNetCoreMetrics.InstrumentationName);
            return builder.AddInstrumentation(() => instrumentation);
        }
    }
}
