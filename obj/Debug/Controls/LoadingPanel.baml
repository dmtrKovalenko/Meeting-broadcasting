   M S B A M L   `   `   `  ����J  FJW media player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:thurst_media_player.Controlsthurst_media_player.Controls  5      d `PresentationFramework.Classic, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35jMclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.ClassicMicrosoft.Windows.Themes 5      /    )thurst_media_player.Controls.LoadingPanel   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :ctr*clr-namespace:thurst_media_player.Controls     5      fclassicThemeMclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Classic     5        � 	Resources  5         bool2visibility  panelBackground �� EndPoint �� 
StartPoint � Color � Offset  panelMessageText �� 
TargetType �� Property �� Value��%3  &	        &	      &	 �     �� 5   
   6'   �� 5	   
   $ 0.5,1&�66   $ 0.5,0&�6G   .��5
      � $ Black��6   $ 1Q�6)   � 5      $ 	#FF1B1B1B��6   5      �� 5   
   " ��6)   .�5      ��  � ��$ Center=�64   �� 5       � ��$ 0,11,0,0q�6'   �� 5       � ��$ WrapWithOverflow=�6-   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 16(�6)   �� 5       � ��$ Center=�62   �� 5       � ��$ Arial)�6+   �� 5       �@J�SnapsToDevicePixels . 64   5      5      .��5      � 
������ $��62��5   �    J� RenderTransformOrigin$ 0.351,-0.462&�6�   $	��119��6�   y�6   �� 	 �� RelativeSource	 �� *FindAncestor+
 �� AncestorType"
 >� �� Path$ 	IsLoading� �� Mode$ OneWay=� �� 	Converter# [   � ColumnDefinitions 5   
   �� 5      $��7* �6   �� 5      $	��10* �6   .+�5!   
   6   0thurst_media_player.Controls.CircularProgressBar  -   5          Name$ progressBar��5!   "   $��Center=�5"      $
��Auto��5#      $��2,4,3,10q�5$      $��44��60   �� 5&   
   -   5         ��Name$ 
txtMessage��5&       �� TextAlignment$ Center=�6(   $��Bottom=�5'      $��Center=�6&   #��[ 5(      $��Loading��5)      
���   �$��64��5*      $��20��6)   $��0,0,6,13q�65   $��1��6G   5,      5-      