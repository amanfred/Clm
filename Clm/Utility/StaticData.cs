using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAgeClm.Utility
{
	public static class StaticData
	{
		public const string DefaultProductImage = "defaultImage.jpg";
		public const string ImageFolder = @"image\ProjectImage";

		//Default DB values for types
		public const string DefaultDbValueTypeGlobalProject = "Global project";
		public const string DefaultDbValueTypeLocalProject = "Local project";
		public const string DefaultDbValueTypeEpic = "Epic";
		public const string DefaultDbValueTypeUserStory = "User story";		
		public const string DefaultDbValueTypeSubTask = "Sub-task";
		public const string DefaultDbValueTypeTask = "Task"; //will be used in the future...

		//Default DB valuse for types
		public const string DefaultDbValueStatusBacklog = "Backlog";
		public const string DefaultDbValueStatusToDo = "To do";
		public const string DefaultDbValueStatusInProgress = "In progress";
		public const string DefaultDbValueStatusReadyToQA = "Ready to QA";
		public const string DefaultDbValueStatusInTest = "In test";
		public const string DefaultDbValueStatusReadyToRelease = "Ready to release";
		public const string DefaultDbValueStatusDone = "Done";

		//Action strings
		public const string ActionValueNameDesc = "name_desc";
		public const string ActionValueNameSortParameter = "NameSortParm";
	}
}
