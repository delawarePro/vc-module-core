﻿using System;
using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.DynamicProperties;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Platform.Core.ChangeLog;

namespace VirtoCommerce.Domain.Order.Model
{
    public abstract class OrderOperation : AuditableEntity, IOperation, ISupportCancellation, IHasDynamicProperties, IHasChangesHistory
    {
        public OrderOperation()
        {
            OperationType = this.GetType().Name;
        }	
        public string OperationType { get; set; }
		public string ParentOperationId { get; set; }
		public string Number { get; set; }
		public bool IsApproved { get; set; }
		public string Status { get; set; }

		public string Comment { get; set; }
		public string Currency { get; set; }
        public decimal Sum { get; set; }
        public IEnumerable<IOperation> ChildrenOperations { get; set; }
		#region ISupportCancelation Members

		public bool IsCancelled { get; set; }
		public DateTime? CancelledDate { get; set; }
		public string CancelReason { get; set; }

		#endregion


		#region IHasDynamicProperties Members
		public string ObjectType { get; set; }
		public ICollection<DynamicObjectProperty> DynamicProperties { get; set; }
        #endregion

        #region IHasChangesHistory
        public ICollection<OperationLog> OperationsLog { get; set; }
        #endregion
    }
}