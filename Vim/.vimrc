set nobackup
set noundofile
set noswapfile

syntax on
set number
set autoindent
set smartindent
set nocompatible
inoremap kj <esc>

set statusline=[%F]%r%m%*%=[%{''.(&fenc!=''?&fenc:&enc).''}][%{&ff}][%l/%L][%p%%]
"set ruler
filetype on

set tabstop=4
set shiftwidth=4
set expandtab
set smarttab

set hlsearch
set incsearch
set ignorecase

set encoding=utf-8
set termencoding=utf-8
set fileencoding=chinese
set fileencodings=ucs-bom,utf-8,chinese
set langmenu=en_US
let $LANG='en_US'

filetype off
set rtp+=~/.vim/bundle/Vundle.vim
call vundle#begin()
Plugin 'VundleVim/Vundle.vim'
Plugin 'kien/ctrlp.vim'
Plugin 'scrooloose/nerdtree'
Plugin 'altercation/vim-colors-solarized'
Plugin 'xolox/vim-misc'
Plugin 'https://git.oschina.net/iamdsy/vim-lua-ftplugin'
Plugin 'Markdown'
Plugin 'AutoComplPop'
call vundle#end()
filetype plugin indent on

let g:ctrlp_working_path_mode = 0
let g:ctrlp_custom_ignore = {
    \ 'dir': '\v[\/]\.(git|hg|svn)$',
    \ 'file': '\v\.(exe|so|dll|meta|iml)$',
    \ 'link': 'some_bad_symbolic_links',
\}

nnoremap nt :NERDTreeToggle<CR>
let NERDTreeShowLineNumbers=1
let NERDTreeAutoCenter=1
let NERDTreeShowHidden=1
let NERDTreeWinSize=21
let g:nerdtree_tabs_open_on_console_startup=1
let NERDTreeIgnore=['\.pyc','\~$','\.swp','\.meta']
let NERDTreeShowBookmarks=1