   M S B A M L   `   `   `  ����   LINE.Emotiv.GH'    !LINE.Emotiv.GH.OutputSettingsForm   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � Title$  UI Integration��
������  � WindowStyle$
 None=� � AllowsTransparency . $	��440��$	��360�� � WindowStartupLocation$ Manual=� � 	Resources    typicalButtonStyle �� 
TargetType �� Property �� Value �� Triggers	 P� Property
 P� Value �� 
StartPoint �� EndPoint � Color � Offset��%�  &	        �� " ��.���  � �� �	#FF252525��  � ��$ 16(���  � ��$ Center=���  � ��$ Center=���  � �� �	#FFE8E8E8 P� 	 �@J�IsMouseOver
 . . ���  � �� �� $ 0.5,0&�$ 0.5,1&�.��� $ 	#FF606060��$	 1.0Q�� $ 	#FF8B8B8B��$	 0.0Q���  � �� �� $ 0.5,0&�$ 0.5,1&�.��� $ 	#FF606060��$	 1.0Q�� $ 	#FF8B8B8B��$	 0.0Q�.���� -   
������ ._�� .+��� ���	#FF404040$��Stretch=�$��Stretch=�$��5,5,5,5q� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q��� 
�������$��5,5,5,5q�$��Stretch=�$��Stretch=��� ���	#FF404040$��1��$
��Left=�$��Stretch=�$��5,5,0,5q��� ���	#FF404040$��1��$��Stretch=�$	��Top=�$��5,5,5,0q��� ���	#FF404040$��1��$��Right=�$��Stretch=�$��0,5,5,5q��� ���	#FF404040$��1��$��Stretch=�$��Bottom=�$��5,0,5,5q��� -    ��Name$ closeButton��#��[  $��Right=�$��80��$��30��$��Bottom=�$��0,0,6,6q���� $��80��$��30��.+��� -    ��Name$ closeButtonRect��
������ �� $��Cancel�� �� TextAlignment$ Center=�����  �� 
TargetType" ��.R��� #��z��#��z��#��z�� J� SnapsToDevicePixels# z #��z����. #��z���� -   $ okButton��#��[  $��Right=�$��80��$��30��$��Bottom=�$��0,0,86,6q���� $��80��$��30��.+��� -   $ okButtonRect��
������ �� $��OK��$ Center=����� " ��.R��� #��z��#��z��#��z��# z #��z����. #��z���� $��Select Outputs��$
��Left=�$��10,5,0,0q�$	��Top=�$��16(����	#FF404040$��Arial)�$
��Bold"��� $��EXPRESSIV States��$
��Left=�$��	11,35,0,0q�$	��Top=�$	��177��$	��338��.��� .+��� -   $��blinkCheckBox��$��Blink��$
��Left=�$��
171,10,0,0q�$	��Top=��� -   $��lwinkCheckBox��$��	Left Wink��$
��Left=�$��	10,31,0,0q�$	��Top=��� -   $��rwinkCheckBox��$��
Right Wink��$
��Left=�$��
171,31,0,0q�$	��Top=��� -	   $��lookDownCheckBox��$��	Look Down��$
��Left=�$��	10,52,0,0q�$	��Top=��� -
   $��lookUpCheckBox��$��Look Up��$
��Left=�$��
171,52,0,0q�$	��Top=��� -   $��lookLeftCheckBox��$��	Look Left��$
��Left=�$��	10,73,0,0q�$	��Top=��� -   $��lookRightCheckBox��$��
Look Right��$
��Left=�$��
171,73,0,0q�$	��Top=��� -   $��clenchCheckBox��$��Clench��$
��Left=�$��	10,94,0,0q�$	��Top=��� -   $��eyebrowCheckBox��$��Eyebrow��$
��Left=�$��
171,94,0,0q�$	��Top=��� -   $��lfActionCheckBox��$��Lower Face Action��$
��Left=�$��
10,115,0,0q�$	��Top=��� -   $��lfPowerCheckBox��$��Lower Face Power��$
��Left=�$��171,115,0,0q�$	��Top=��� -   $��ufActionCheckBox��$��Upper Face Action��$
��Left=�$��
10,136,0,0q�$	��Top=��� -   $��ufPowerCheckBox��$��Upper Face Power��$
��Left=�$��171,136,0,0q�$	��Top=��� -   $��smileCheckBox��$��Smile��$
��Left=�$��	10,10,0,0q�$	��Top=��� $��AFFECTIV States��$
��Left=�$��
11,217,0,0q�$	��Top=�$��96��$	��338��.��� .+��� -   $��engagementCheckBox��$��Engagment/Boredom��$
��Left=�$��	10,10,0,0q�$	��Top=��� -   $��exciteLongCheckBox��$��Excitement (Long-Term)��$
��Left=�$��
171,10,0,0q�$	��Top=��� -   $��exciteShortCheckBox��$��Excitement (Short-Term)��$
��Left=�$��	10,31,0,0q�$	��Top=��� -   $��frustrationCheckBox��$��Frustration��$
��Left=�$��
171,31,0,0q�$	��Top=��� -   $��meditationCheckBox��$��
Meditation��$
��Left=�$��	10,52,0,0q�$	��Top=��� -   $��valanceCheckBox��$��Valance��$
��Left=�$��
171,52,0,0q�$	��Top=��� $��COGNATIV States��$
��Left=�$��
11,318,0,0q�$	��Top=�$��76��$	��338��.��� .+��� -   $��cogActionCheckBox��$��Cognativ Action��$
��Left=�$��	10,10,0,0q�$	��Top=��� -   $��cogPowerCheckBox��$��Power��$
��Left=�$��
171,10,0,0q�$	��Top=��� -   $��cogActiveCheckBox��$��	Is Active��$
��Left=�$��	10,31,0,0q�$	��Top=�