## 描述

做的自动寻路的功能	

## 使用方法

### 地形烘焙

我这里粗略讲解,详细的自己在网上学习一下

把场景中的地形和物体的navigation static勾选上

![image-20200605143315641](README.assets/image-20200605143315641.png)

打开navigation

![image-20200605143206456](README.assets/image-20200605143206456.png)

选中bake选项卡,并调节参数,然后点击bake

![image-20200605143359216](README.assets/image-20200605143359216.png)

就可以在场景中看到地面上有个蓝色的地形

![image-20200605143451887](README.assets/image-20200605143451887.png)

### 插件使用

把player_worker拖入场景中,

插件写在x_NavPlayer上

接口为

```csharp
public void SetTargetPosition(Vector3 _v3TargetPosition)
```

x_GroundClick

为demo演示脚本,实际根据自己的喜好来做