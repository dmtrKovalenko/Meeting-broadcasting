   M S B A M L   `   `   `  ����J  FJW media player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:thurst_media_playerthurst_media_player  5   	   K*clr-namespace:thurst_media_player.Controlsthurst_media_player.Controls  5   	   $    thurst_media_player.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:thurst_media_player     5   	   :mar*clr-namespace:thurst_media_player.Controls     5   	     � Title$  Meeting Broadcasting��5
   	   $��216.165��6&   $��338.59��67    � 
ResizeMode$ CanMinimize=�6F    � Icon$ jw_icon.ico��6_    � DataContext 5	   	   ��  �� RelativeSource ��  �� Mode$
 Self=�.��5      �  � RowDefinitions 5   
   �� 5      $	��40* �6   �� 5      $
��136* �6   �� 5      $	��11* �6    � ColumnDefinitions 5   
   �� 5      $��0* �6   �� 5      $
��101* �6   �� 5      $
��188* �6   �� 5      $	��42* �6   �� 5      $��9* �6   .+�5   
   �� -   5         ��Name$
 play��5      |�.     PlayButtonStyle#��[  5      $��Center=�5      $��Bottom=�5      
������ 	 J� RenderTransformOrigin$	 0.5,0.5&�5      $��0q�5       
 � Cursor$

 Hand��5!       J� IsHitTestVisible .  J� 	AllowDrop . $��54��5$      $	��125��6   $	��120��6    $��2��6-   $��	10,0,49,0q�6=   $��1��6P   ��5%      �� 5&       �� ImageSource$ Resources/pause-icon.png��6   5(      �� 5*   
   -   5         ��Name$ Duration��5*      $��00:00:00��5+      $
��Left=�5,      $��Bottom=�5-      $��45��5.      $��Times New Roman)�5/      $��29(�50      $
��Bold"�51      $	 -1.634,-0.643&�52      $	��132��53      $��5,0,0,86q�6   $��1��6/   $��2��6?   $��1��6S   �� 55   
   -   5         ��Name$ volumeSlider��55      $��0,10,4,0q�56      $	��Top=�6   $��Right=�6/    �� IsMoveToPointEnabled .  �� Orientation$ Vertical=�58      |�.  $��95��59      $��29��6   $��3��5:      $��1��6!    � Value$	 0.5Q�5;   (    � Maximum$ 1Q�64   $
��Auto=�5<       �� TickPlacement$
 Both=�5=      �� 5?   
   
���   �$��3q�5@       �� CornerRadius$ 10��5A      $	��0,5q�5B      $��37��6   $��Right=�5C      $��3��6-   $��2��5D      $��1��6"   �� 5F   
   -   5        $
 mute��5F      |�.  
������ $��3��5H      $��1��6   $��Right=�5I      $	��Top=�6!   $��	0,105,4,0q�5J      $��0q�5K      $��26��5M      $��29��6     
VolumeIcon#��[ 5N      .   (thurst_media_player.Controls.MarqueeText  5P   
   -   5          Name$ marqueeAttention��5P      
������ $��21(�5R         MarqueeTimeInSeconds$ 18Q�5S      
���   �$��0,-1,-167,4q�5T   -   $��5��5U      /   )thurst_media_player.Controls.LoadingPanel  5W   
   $��0,93,161,-2q�6   $��56��60   $��1��5Y      $��1��5Z      $��Center=�5[      $��2��5\      $��2��6/      	IsLoading 5X      �� *	IsLoading+5\   /   �� 5^   
   -   5         ��Name$ title��5^      $��JW Meeting Player��5_      $��4��5`      $	��249��6)   $
��Left=�5a      $��45,2,0,1q�5b      $��29(�6&   $
��Wrap=�5c      $��Arial)�6(    �� TextAlignment$ Center=�6;   �� 5e   
   $��5��6   	 �� X1$ 0��5f      	 �� Y1$ 0��6   	 �� X2$	 333��6   	 �� Y2$ 0��6&   
���   �$��3��5h      5i      5j      