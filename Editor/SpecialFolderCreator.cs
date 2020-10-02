using System.Linq;
using UnityEditor;

namespace Kogane.Internal
{
	internal static class SpecialFolderCreator
	{
		private const string MENU_ITEM_ROOT                       = "Assets/Create/Special Folder/";
		private const string FOLDER_NAME_EDITOR                   = "Editor";
		private const string FOLDER_NAME_EDITOR_DEFAULT_RESOURCES = "Editor Default Resources";
		private const string FOLDER_NAME_GIZMOS                   = "Gizmos";
		private const string FOLDER_NAME_PLUGINS                  = "Plugins";
		private const string FOLDER_NAME_RESOURCES                = "Resources";
		private const string FOLDER_NAME_STANDARD_ASSETS          = "Standard Assets";
		private const string FOLDER_NAME_STREAMING_ASSETS         = "StreamingAssets";

		[MenuItem( MENU_ITEM_ROOT + FOLDER_NAME_EDITOR )]
		private static void CreateFolder_Editor() => CreateFolder( FOLDER_NAME_EDITOR );

		[MenuItem( MENU_ITEM_ROOT + FOLDER_NAME_EDITOR_DEFAULT_RESOURCES )]
		private static void CreateFolder_EditorDefaultResources() => CreateFolder( FOLDER_NAME_EDITOR_DEFAULT_RESOURCES );

		[MenuItem( MENU_ITEM_ROOT + FOLDER_NAME_GIZMOS )]
		private static void CreateFolder_Gizmos() => CreateFolder( FOLDER_NAME_GIZMOS );

		[MenuItem( MENU_ITEM_ROOT + FOLDER_NAME_PLUGINS )]
		private static void CreateFolder_Plugins() => CreateFolder( FOLDER_NAME_PLUGINS );

		[MenuItem( MENU_ITEM_ROOT + FOLDER_NAME_RESOURCES )]
		private static void CreateFolder_Resources() => CreateFolder( FOLDER_NAME_RESOURCES );

		[MenuItem( MENU_ITEM_ROOT + FOLDER_NAME_STANDARD_ASSETS )]
		private static void CreateFolder_StandardAssets() => CreateFolder( FOLDER_NAME_STANDARD_ASSETS );

		[MenuItem( MENU_ITEM_ROOT + FOLDER_NAME_STREAMING_ASSETS )]
		private static void CreateFolder_StreamingAssets() => CreateFolder( FOLDER_NAME_STREAMING_ASSETS );

		private static void CreateFolder( string folderName )
		{
			var selectedFolder = Selection
					.GetFiltered<DefaultAsset>( SelectionMode.Assets )
					.FirstOrDefault()
				;

			var selectedFolderPath = AssetDatabase.GetAssetPath( selectedFolder );
			var parentFolderPath   = string.IsNullOrWhiteSpace( selectedFolderPath ) ? "Assets" : selectedFolderPath;
			var createdFolderGuid  = AssetDatabase.CreateFolder( parentFolderPath, folderName );
			var createdFolderPath  = AssetDatabase.GUIDToAssetPath( createdFolderGuid );
			var createdFolder      = AssetDatabase.LoadAssetAtPath<DefaultAsset>( createdFolderPath );

			EditorGUIUtility.PingObject( createdFolder );
		}
	}
}