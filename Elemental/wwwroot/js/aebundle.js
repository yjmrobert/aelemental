window.aedropdown={dropdowns:[],initialize:e=>{window.aedropdown.dropdowns.push(e)},dispose:e=>{window.aedropdown.dropdowns=window.aedropdown.dropdowns.filter((t=>t!==e))},toggleVisibility:e=>{document.querySelector(`[ae-id="${e}"]`).classList.toggle("visible")}},document.addEventListener("click",(function(e){window.aedropdown.dropdowns.forEach((t=>{let n=document.querySelector(`[ae-id="${t}"]`);n.classList.contains("visible")&&!n.contains(e.target)&&n.classList.remove("visible")}))})),BlazorScrollToId=function(e){const t=document.getElementById(e);t instanceof HTMLElement&&t.scrollIntoView({behavior:"smooth",block:"start",inline:"nearest"})},ScrollPos=function(e){if(e instanceof HTMLElement){var t=window.getPositionOnDoc(e);window.scrollTo(0,t.top)}},ScrollPosFromId=function(e){ScrollPos(document.getElementById(e))},(()=>{window.BlazorClipboadInterop=window.BlazorClipboadInterop||{},window.BlazorClipboadInterop.ListeningForPasteEvents=function(e,t){e.addEventListener("paste",(function(e){BlazorClipboadInterop.pasteEvent(e,t)}))};const e=e=>new Promise(((t,n)=>{const o=new FileReader;o.readAsDataURL(e),o.onload=()=>t(o.result),o.onerror=e=>n(e)}));window.BlazorClipboadInterop.pasteEvent=async function(t,n){var o=await navigator.clipboard.read(),i=[];for(let t=0;t<o.length;t++){var a={};i.push(a);for(let n=0;n<o[t].types.length;n++){const i=o[t].types[n],d=await o[t].getType(i);if(d)if(1==i.startsWith("text")){const e=await d.text();a[i]=e}else a[i]=await e(d)}}await n.invokeMethodAsync("Pasted",i),t.preventDefault()}})(),window.getDimensions=function(e){return{width:e.clientWidth,height:e.clientHeight}},window.getPosition=function(e){var t=e.getBoundingClientRect();return{top:Math.floor(t.top),left:Math.floor(t.left),bottom:Math.floor(t.bottom),right:Math.floor(t.right)}},window.getPositionOnDoc=function(e){var t=window.getPosition(e);return{top:Math.floor(t.top+window.pageYOffset),left:Math.floor(t.left+window.pageXOffset),bottom:Math.floor(t.bottom+window.pageYOffset),right:Math.floor(t.right+window.pageXOffset)}},window.setZIndex=function(e,t){e.style.zIndex=t},window.initializeSidebar={initialize:e=>{e.addEventListener("mouseover",(function(){if(document.querySelector(".ae.side-nav").clientWidth<=56){var t=e.getBoundingClientRect();e.querySelector("span").style.top=Math.floor(t.top)+"px",e.querySelector("span").classList.add("show")}})),e.addEventListener("mouseout",(function(){document.querySelector(".ae.side-nav").clientWidth<=56&&e.querySelector("span").classList.remove("show")}))},getInnerHeight:function(){return window.innerHeight},getInnerWidth:function(){return window.innerWidth},registerResizeCallback:function(){window.addEventListener("resize",initializeSidebar.resized)},resized:function(){DotNet.invokeMethodAsync("Elemental","OnBrowserResize").then((e=>e))}},window.modalHelper={scrollTop:null,scrollLeft:null,lockBodyScrolling:function(){this.scrollTop=document.documentElement.scrollTop,this.scrollLeft=document.documentElement.scrollLeft,document.getElementsByTagName("html")[0].style.overflowY="scroll",document.getElementsByTagName("body")[0].style.top=-document.documentElement.scrollTop+"px",document.getElementsByTagName("body")[0].style.position="fixed",document.getElementsByTagName("body")[0].style.width="100%",document.getElementsByClassName("modal")[0].style.top=-document.documentElement.scrollTop+"px"},unlockBodyScrolling:function(){document.getElementsByTagName("html")[0].style.overflowY="auto",document.getElementsByTagName("body")[0].style.top="auto",document.getElementsByTagName("body")[0].style.width="auto",document.getElementsByTagName("body")[0].style.position="static",window.scrollTo(this.scrollLeft,this.scrollTop)},setModalPosition:function(){}},window.saveAsFile=(e,t)=>{if(navigator.msSaveBlob){for(var n=atob(t),o=new Uint8Array(n.length),i=0;i<n.length;i++)o[i]=n.charCodeAt(i);n=null;var a=new Blob([o.buffer],{type:"application/octet-stream"});o=null,navigator.msSaveBlob(a,e),a=null}else{var d=document.createElement("a");d.download=e,d.href="data:application/octet-stream;base64,"+t,document.body.appendChild(d),d.click(),document.body.removeChild(d)}},(()=>{function e(e){e.forEach((e=>function(e){$(`.ae.sidenav-container .${e}`).removeClass(e),$(`.sidenav-group-wrapper .${e}`).removeClass(e)}(e)))}function t(){let e=window.location.pathname.substr(1).split("/")[0];return 0!=$(`[data-nav-href="/${e}"]`).children(`[href*="/${e}/"]`).length}window.sidenav={sidenavExpandThreshold:null,sidenavShrinkThreshold:null,stayCollapse:!1,toggleExpansion:e=>{null==e&&(e=$(".ae.sidenav").hasClass("expanded"));var t=$(".ae.sidenav"),n=$(".ae.content-wrapper");e?(t.removeClass("expanded"),n.css("margin-left",60)):t.addClass("expanded"),$(window).width()>window.sidenav.sidenavExpandThreshold&&(e||n.css("margin-left",300))},initializeSidenav:(n,o,i,a)=>{window.sidenav.sidenavExpandThreshold=o,window.sidenav.sidenavShrinkThreshold=i,window.sidenav.stayCollapse=a;let d=$(".ae.sidenav"),s=$(".ae.sidenav-main-menu"),l=$(window);n&&l.width()>window.sidenav.sidenavExpandThreshold&&t()&&window.sidenav.toggleExpansion(!1),window.sidenav.stayCollapse||(l.resize((()=>{l.width()>window.sidenav.sidenavExpandThreshold&&!d.hasClass("expanded")&&t()?window.sidenav.toggleExpansion(!1):l.width()<window.sidenav.sidenavShrinkThreshold&&d.hasClass("expanded")&&window.sidenav.toggleExpansion(!0)})),s.children(".ae.sidenav-item").mouseenter((t=>{let n=$(t.currentTarget).attr("href"),o=$(`[data-nav-href="${n}"]`);if(l.width()<window.sidenav.sidenavShrinkThreshold)return 0!=o.children(`[href*="${n}/"]`).length?(e(["expanded"]),o.addClass("expanded"),void window.sidenav.toggleExpansion(!1)):void window.sidenav.toggleExpansion(!0)})),d.mouseleave((()=>{l.width()<window.sidenav.sidenavShrinkThreshold&&window.sidenav.toggleExpansion(!0)})))},updateNav:t=>{let n=window.location.pathname.substr(1),o=n.split("/");if(e(["expanded","exact","active"]),$(`[href="/${n}"]`).addClass("exact"),o.length>0){let e=o[0],n=$(`[data-nav-href="/${e}"]`);if($(`[href="/${e}"]`).addClass("active"),(!t||$(window).width()>window.sidenav.sidenavExpandThreshold)&&(n.addClass("expanded"),$(".ae.sidenav").hasClass("expanded")&&0==n.children(`[href*="/${e}/"]`).length?window.sidenav.toggleExpansion(!0):$(".ae.sidenav").hasClass("expanded")||0==n.children(`[href*="/${e}/"]`).length||window.sidenav.toggleExpansion(!1),o.length>1)){let t=`${e}/${o[1]}`,i=n.children(`[href="/${t}"]`);if(0==i.length)window.sidenav.toggleExpansion(!0);else{i.addClass("active");let e=$(`[data-nav-href="/${t}"]`);if(e.addClass("expanded"),o.length>2){let n=`${t}/${o[2]}`;e.children(`[href="/${n}"]`).addClass("active")}}}}}},$(document).ready((function(){}))})(),window.initializeToolTip=(e,t)=>{e.addEventListener("mouseout",(()=>{t.invokeMethodAsync("OnMouseOutHideToolTip")}))},window.virtualScrolling={getScrollView:e=>({scrollTop:parseInt(e.scrollTop),clientHeight:e.clientHeight})},window.walkThroughHelper={walkThrough:function(e){var t=e.dotNetReference,n=e.steps.sort(((e,t)=>e.order-t.order)),o={modifiers:[{name:"offset",options:{offset:[0,3]}},{name:"flip",options:{allowedAutoPlacements:["top","bottom","right","left"]}},{name:"eventListeners",options:{resize:!0,vfdvd:!0}}]};const i=new Shepherd.Tour({defaultStepOptions:{cancelIcon:{enabled:!0},scrollTo:{behavior:"smooth",block:"center"},canClickTarget:!!e.clickable,popperOptions:o},useModalOverlay:!!e.overlay});n.forEach((e=>{i.addStep({title:e.title,text:e.content,attachTo:{element:e.id,on:e.position},buttons:this.getButtons(e.order,n.length),scrollTo:!!e.scrollTo,popperOptions:e.overlap?o:{modifiers:[{name:"preventOverflow",options:{altAxis:!1}}]},id:e.id,arrow:!!e.arrow})})),i.on("complete",(()=>{t.invokeMethodAsync("WalkthroughCompleted")})),i.start()},getButtons:function(e,t){var n=[];return 1!==e&&n.push({action(){return this.back()},classes:"shepherd-button-secondary",text:"Back"}),n.push({action(){return this.next()},text:e==t?"Exit":"Next"}),n}};
//# sourceMappingURL=aebundle.map