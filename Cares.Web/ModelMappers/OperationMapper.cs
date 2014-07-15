﻿
using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    public static class OperationMapper
    {
        #region Public
        #region Entity To Model
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.Operation CreateFrom(this Operation source)
            {
                return new ApiModel.Operation()
                {
                    OperationId = source.OperationId,
                    OperationCode = source.OperationCode,
                    OperationName = source.OperationName
                };
            }
        #endregion
        #region Model To Entity
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static Operation CreateFrom(this ApiModel.Operation source)
        {
            return new Operation()
            {
                OperationId = source.OperationId,
                OperationCode = source.OperationCode,
                OperationName = source.OperationName
            };
        }
        
        #endregion
        #endregion
    }
}