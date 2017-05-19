# Copyright David Stone 2015.
# Distributed under the Boost Software License, Version 1.0.
# (See accompanying file LICENSE_1_0.txt or copy at
# http://www.boost.org/LICENSE_1_0.txt)

class optimize:
	__general_flags_debug = [
		'-O1',
		'-march=native',
	]
	compile_flags_debug = __general_flags_debug + [
	]
	
	__general_flags_release = [
		'-Ofast',
		'-march=native',
		'-flto=thin',
	]
	compile_flags_release = __general_flags_release + [
		'-emit-llvm',
	]

	link_flags_debug = [
	]
	link_flags_release = __general_flags_release
