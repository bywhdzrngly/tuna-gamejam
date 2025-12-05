

 一整套 Git 常用命令（开始→开发→结束），每条都有注释

把下面直接发给队友。假设远端仓库地址是 `https://github.com/bywhdzrngly/tuna-gamejam.git`

---

## A. 第一次在别人电脑上的操作（Clone 并切到 dev）

```bash
# 切到你想把项目放的位置（示例：D盘）
D:
cd D:\UnityProjects

# 把仓库复制到本地（只需做一次）
git clone https://github.com/bywhdzrngly/tuna-gamejam.git
# 作用：把远端仓库完整下载到本地

cd tuna-gamejam

# 获取远端所有分支并切换到 dev（如果 dev 已由 owner 创建）
git fetch
git checkout dev
# 作用：切换到团队的开发分支 dev，后续都从 dev 新建自己的分支
```

---

## B. 每天开始工作前（更新 dev）

```bash
git checkout dev
# 作用：切换到 dev 分支，确保你在团队主开发线上

git pull origin dev
# 作用：把远端最新的 dev 拉到本地，避免冲突（必须做）
```

---

## C. 创建你的功能分支（每做一个功能都新建分支）

```bash
git checkout -b feature/你的名字-简短功能描述
# 例：git checkout -b feature/zhaoxy-startui
# 作用：在本地创建并切换到新分支，方便隔离开发
```

---

## D. 开发中常用（保存进本地仓库）

```bash
git add .
# 作用：把你修改或新增的文件放到暂存区，准备提交

git commit -m "类型: 简短说明"
# 例：git commit -m "feat: opening UI click-to-next image"
# 作用：把暂存区的修改记录为一次提交（commit）
```

> 提交类型建议（你们可以统一用这些）：
>
> * `feat:` 新功能
> * `fix:` 修 bug
> * `docs:` 文档
> * `asset:` 美术资源
> * `chore:` 构建/配置项

---

## E. 推送你的分支到远端（让别人能看到）

```bash
git push -u origin feature/你的名字-简短功能描述
# 作用：把你本地分支推到远端并建立追踪（-u 仅第一次用）
```

---

## F. 在 GitHub 上发 Pull Request（合并到 dev）

* 在仓库页面点 “Compare & pull request” 或 New pull request
* Base 选择：`dev`，Compare 选择：`feature/xxx`
* 写清楚你做了什么 → Request review（至少让一位队友看一遍）
* PR 通过后 click **Merge**（或由负责人合并）

> 合并完成后，如果合并者删除了远端分支，记得本地也删掉。

---

## G. 合并后本地清理 & 更新 dev

```bash
# 回到 dev
git checkout dev

# 拉取最新 dev（包含刚才合并的改动）
git pull origin dev

# 删除本地不需要的分支（可选）
git branch -d feature/你的名字-简短功能描述
```

---

## H. 如果你在本地遇冲突（简单流程）

```bash
# 当 git pull 或 rebase 遇冲突时
git status
# 查看冲突文件，手动打开并解决冲突（编辑文件，保存）

git add <冲突已解决的文件>
git commit
# 然后继续 push（如果是 rebase 后需强制推送）
git push origin feature/xxx
```

---

## I. 退出/结束当天（保持主线干净）

1. 确保你当前分支的工作都 commit 并 push。
2. 回到 `dev` 并 pull（保持 dev 是最新的）：

```bash
git checkout dev
git pull origin dev
```

---

> **备注**：如果你不是仓库 Collaborator（没有写权限），则需 Fork → 新分支 → Push 到你自己的 Fork → 发 PR 到原仓库。

---

# 3) UI 是什么？简单解释（给完全没做过的队友）

* **UI（User Interface）用户界面**：玩家和游戏交互的所有界面元素，例如菜单、按钮、对话框、血条、提示文字等。
* Unity 里主要概念：

  * **Canvas**：所有 UI 的根（画布）
  * **RectTransform**：UI 元素位置/大小的组件（替代 Transform）
  * **Image**：用来显示图片（背景、按钮图）
  * **Text / TextMeshPro**：显示文字
  * **Button**：带可点击功能的 UI（有 OnClick 事件）
  * **EventSystem**：负责接收鼠标/触摸等输入（每个场景必有）
  * **CanvasScaler**：负责适配不同分辨率（常设为 Scale With Screen Size）

**举例**：做开始界面时，你会建一个 Canvas，在 Canvas 下放一个 Image（背景）和一个 Button（Start）。Button 的 OnClick 可以连到你写的脚本方法启动游戏。

---




